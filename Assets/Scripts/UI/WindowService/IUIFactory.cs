using RolePlayer.UI.WindowService.Windows;

namespace RolePlayer.UI.WindowService
{
  public interface IUIFactory
  {
    BaseWindow Create(WindowId windowId);
  }
}
