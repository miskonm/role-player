using RolePlayer.SaveLoad;
using Zenject;

namespace RolePlayer.Infrastructure
{
  public class BootstrapInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      InstallSaveLoadService();
    }

    private void InstallSaveLoadService()
    {
      Container.Bind<SaveLoadContainer>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }
  }
}
