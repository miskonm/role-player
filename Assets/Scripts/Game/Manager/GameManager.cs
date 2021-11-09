using Foundation;
using RolePlayer.Game.Elements;
using RolePlayer.Game.Player;
using RolePlayer.Infrastructure.SceneManagement;
using Zenject;

namespace RolePlayer.Game.Manager
{
  public class GameManager : AbstractBehaviour, IHealthChanged
  {
    private ISceneManager _sceneManager;
    
    private Health _playerHealth;
    private bool _isLoading;

    [Inject]
    public void Construct(ISceneManager sceneManager)
    {
      _sceneManager = sceneManager;
    }

    private void Start()
    {
      FindPlayer();
      Observe(_playerHealth.OnHealthChanged);
    }

    private void FindPlayer()
    {
      var pl = FindObjectOfType<PlayerMove>();
      _playerHealth = pl.GetComponent<Health>();
    }

    void IHealthChanged.Do()
    {
      if (_isLoading || _playerHealth.Current > 0)
        return;
      
      _isLoading = true;
      _sceneManager.LoadSceneAsync(SceneName.Menu);
    }
  }
}
