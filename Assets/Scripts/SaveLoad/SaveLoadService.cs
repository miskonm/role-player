using RolePlayer.Data;
using UnityEngine;

namespace RolePlayer.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string SaveDataKey = "Progress";

    private readonly SaveLoadContainer _saveLoadContainer;

    public ProgressData ProgressData { get; private set; }

    public SaveLoadService(SaveLoadContainer saveLoadContainer)
    {
      _saveLoadContainer = saveLoadContainer;
    }

    public void Register(ILoadProgress loader)
    {
      _saveLoadContainer.Add(loader);
    }

    public void Save()
    {
      foreach (ISaveLoadProgress saver in _saveLoadContainer.Savers)
        saver.Save(ProgressData);

      PlayerPrefs.SetString(SaveDataKey, ProgressData.ToJson());
    }

    public void Load()
    {
      ProgressData = PlayerPrefs.GetString(SaveDataKey)?.ToDeserialized<ProgressData>() ?? new ProgressData();

      foreach (ILoadProgress loader in _saveLoadContainer.Loaders)
        loader.Load(ProgressData);
    }
  }
}
