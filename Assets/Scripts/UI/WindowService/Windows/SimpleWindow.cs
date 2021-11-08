using UnityEngine.UI;
using Zenject;

namespace RolePlayer.UI.WindowService.Windows
{
  public class SimpleWindow : BaseWindow
  {
    public Button CloseButton;
    public Button NextWindowButton;
    public WindowId NextWindowId;
    public bool NeedClearStack;

    private IWindowService _windowService;

    [Inject]
    public void Construct(IWindowService windowService)
    {
      _windowService = windowService;
    }

    private void Awake()
    {
      if (CloseButton != null)
        CloseButton.onClick.AddListener(Close);

      if (NextWindowButton != null)
        NextWindowButton.onClick.AddListener(OpenNextWindow);
    }

    private void OpenNextWindow() =>
      _windowService.Show(NextWindowId, NeedClearStack);
  }
}
