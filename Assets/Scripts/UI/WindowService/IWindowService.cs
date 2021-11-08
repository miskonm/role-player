using RolePlayer.UI.WindowService.Windows;

namespace RolePlayer.UI.WindowService
{
  public interface IWindowService
  {
    BaseWindow CurrentWindow { get; }
    
    void Show(WindowId windowId, bool needClearStack = false);
  }
}
