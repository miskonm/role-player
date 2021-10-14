using RolePlayer.SaveLoad;
using UnityEngine;
using Zenject;

namespace RolePlayer
{
  public class GameStarter : MonoBehaviour
  {
    public ExampleView ExampleView;

    private ISaveLoadService _saveLoadService;

    [Inject]
    public void Construct(ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
    }

    private void Start()
    {
      _saveLoadService.Register(ExampleView);
      _saveLoadService.Load();
    }
  }
}
