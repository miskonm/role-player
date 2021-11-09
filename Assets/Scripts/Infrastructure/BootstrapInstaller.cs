using Course.Managers.LocalizationManager;
using Course.Managers.SceneManager;
using Course.Managers.TimeScaleManager;
using RolePlayer.Infrastructure.AssetManagement;
using RolePlayer.SaveLoad;
using RolePlayer.UI.WindowService;
using UnityEngine;
using Zenject;

namespace RolePlayer.Infrastructure
{
  public class BootstrapInstaller : MonoInstaller
  {
    public GameObject LocalizationManagerPrefab;
    
    public override void InstallBindings()
    {
      InstallAssetProvider();
      InstallSaveLoadService();
      InstallUiWindowService();

      InstallLocalization();
      InstallSceneManager();
      InstallTimeManager();
    }

    private void InstallAssetProvider()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    private void InstallSaveLoadService()
    {
      Container.Bind<SaveLoadContainer>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void InstallUiWindowService()
    {
      Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
      Container.Bind<IWindowService>().To<WindowService>().AsSingle();
    }

    private void InstallLocalization()
    {
      Container.Bind<ILocalizationManager>().To<LocalizationManager>()
       .FromComponentInNewPrefab(LocalizationManagerPrefab).AsSingle();
    }

    private void InstallSceneManager()
    {
      Container.Bind<ISceneManager>().To<SceneManager>().FromNewComponentOnNewGameObject().AsSingle();
    }

    private void InstallTimeManager()
    {
      Container.Bind<ITimeScaleManager>().To<TimeScaleManager>().FromNewComponentOnNewGameObject().AsSingle();
    }
  }
}
