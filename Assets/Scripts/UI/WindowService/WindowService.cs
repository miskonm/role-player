using System.Collections.Generic;
using RolePlayer.UI.WindowService.Windows;

namespace RolePlayer.UI.WindowService
{
  public class WindowService : IWindowService
  {
    private readonly IUIFactory _uiFactory;

    private readonly Stack<BaseWindow> _windows = new Stack<BaseWindow>();

    public BaseWindow CurrentWindow => GetCurrentWindow();

    public WindowService(IUIFactory uiFactory) =>
      _uiFactory = uiFactory;

    public void Show(WindowId windowId, bool needClearStack = false)
    {
      if (needClearStack)
        ClearStack();

      if (CurrentWindow != null)
        CurrentWindow.Hide();

      BaseWindow window = _uiFactory.Create(windowId);
      window.OnClose(RemoveFromStack);

      _windows.Push(window);
    }

    private BaseWindow GetCurrentWindow() =>
      _windows.Count > 0 ? _windows.Peek() : null;

    private void ClearStack()
    {
      while (_windows.Count > 0)
        CurrentWindow.Close();
    }

    private void RemoveFromStack()
    {
      if (_windows.Count > 0)
        _windows.Pop();

      if (CurrentWindow != null)
        CurrentWindow.Show();
    }
  }
}
