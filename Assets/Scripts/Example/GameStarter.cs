using RolePlayer.UI.WindowService;
using UnityEngine;
using Zenject;

namespace RolePlayer
{
  public class GameStarter : MonoBehaviour
  {
    private IWindowService _windowService;

    [Inject]
    public void Construct(IWindowService windowService)
    {
      _windowService = windowService;
    }

    private void Start()
    {
      _windowService.Show(WindowId.Example);
    }
  }
}
