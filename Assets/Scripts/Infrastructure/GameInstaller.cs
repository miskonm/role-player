using RolePlayer.Game.Input;
using Zenject;

namespace RolePlayer.Infrastructure
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      InstallInput();
    }

    private void InstallInput()
    {
      Container.Bind<IInputService>().To<InputService>().AsSingle();
    }
  }
}
