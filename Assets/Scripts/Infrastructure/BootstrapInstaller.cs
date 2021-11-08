using RolePlayer.Infrastructure.AssetManagement;
using RolePlayer.SaveLoad;
using RolePlayer.UI.WindowService;
using Zenject;

namespace RolePlayer.Infrastructure
{
  public class BootstrapInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      InstallAssetProvider();
      InstallSaveLoadService();
      InstallUiWindowService();
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
  }
}
