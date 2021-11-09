using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

namespace Course.Editor.Config
{
  public abstract class AbstractConfigImporter
  {
    sealed class Aborted : Exception
    {
    }

    readonly string sheetId;
    readonly string page;

    //Идентификатор и страницу
    protected AbstractConfigImporter(string sheetId, string page)
    {
      this.sheetId = sheetId;
      this.page = page;
    }

    protected Task Progress(float progress)
    {
      if (EditorUtility.DisplayCancelableProgressBar(page, "Processing data...", 0.3f + progress * 0.7f))
        throw new Aborted();

      return Task.CompletedTask;
    }

    protected abstract Task ProcessData(IList<IList<object>> values);

    //Загрузка
    IEnumerator ImporterCoroutine()
    {
      // Аутентификация

      var credentialsJson = AssetDatabase.LoadAssetAtPath<TextAsset>(
        "Assets/Scripts/Course/Editor/Config/creds.json");

      //Запрос токена
      var authTask = GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.Load(new MemoryStream(credentialsJson.bytes)).Secrets,

        //Запрашиваемые права
        new string[] { SheetsService.Scope.SpreadsheetsReadonly },
        "user",
        CancellationToken.None,

        //Где хранить токен
        new FileDataStore("UnityGoogleApis", false));

      for (int i = 0; i < 120; i++)
      {
        if (authTask.IsCompleted)
          break;

        yield return null;
      }

      //Показ прогресс бара
      while (!authTask.IsCompleted)
      {
        if (EditorUtility.DisplayCancelableProgressBar(page, "Waiting for authentication...", 0.0f))
        {
          EditorUtility.ClearProgressBar();
          Debug.LogWarning("Import cancelled by the user");

          yield break;
        }

        yield return null;
      }

      //Ключ авторизации
      UserCredential credential = authTask.Result;

      // Загрузка данных

      var service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = "Unity Config Importer",
      });

      var request = service.Spreadsheets.Values.Get(sheetId, page);
      var requestTask = request.ExecuteAsync();

      while (!requestTask.IsCompleted)
      {
        if (EditorUtility.DisplayCancelableProgressBar(page, "Downloading data...", 0.15f))
        {
          EditorUtility.ClearProgressBar();
          Debug.LogWarning("Import cancelled by the user");

          yield break;
        }

        yield return null;
      }

      var response = requestTask.Result;

      //Список строк, числа будут пересчитаны
      var values = response.Values;

      // Обработка данных

      if (EditorUtility.DisplayCancelableProgressBar(page, "Processing data...", 0.3f))
      {
        EditorUtility.ClearProgressBar();
        Debug.LogWarning("Import cancelled by the user");

        yield break;
      }

      //Обрабатываем данные
      var processTask = ProcessData(values);

      while (!processTask.IsCompleted)
        yield return null;

      try
      {
        processTask.Wait(); // убеждаемся, что возможные исключения обработаны
      }
      catch (Aborted)
      {
        EditorUtility.ClearProgressBar();
        Debug.LogWarning("Import cancelled by the user");

        yield break;
      }
      catch (Exception e)
      {
        Debug.LogException(e);
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("Error", "Import failed!", "OK");

        yield break;
      }

      // Готово

      EditorUtility.ClearProgressBar();
      EditorUtility.DisplayDialog("Done", "Import was successful!", "OK");
    }

    protected void DoImport()
    {
      EditorCoroutineUtility.StartCoroutineOwnerless(ImporterCoroutine());
    }
  }
}
