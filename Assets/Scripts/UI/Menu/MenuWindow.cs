using System.Threading.Tasks;
using Course.Base;
using Course.Managers.SceneManager;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RolePlayer.UI.Menu
{
  public class MenuWindow : AbstractBehaviour, IOnBeginSceneLoad
  {
    public Button PlayButton;
    public GameObject LoadingBar;

    private ISceneManager _sceneManager;

    [Inject]
    public void Construct(ISceneManager sceneManager) => 
      _sceneManager = sceneManager;

    private void Awake() => 
      PlayButton.onClick.AddListener(Play);

    protected override void OnEnable()
    {
      base.OnEnable();
      Observe(_sceneManager.OnBeginSceneLoad);
    }

    async Task IOnBeginSceneLoad.Do()
    {
      PlayButton.interactable = false;
      LoadingBar.SetActive(true);
    }

    private void Play() =>
      _sceneManager.LoadSceneAsync(SceneName.Game);
  }
}
