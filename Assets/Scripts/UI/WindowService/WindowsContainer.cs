using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RolePlayer.UI.WindowService
{
  [CreateAssetMenu(fileName = nameof(WindowsContainer), menuName = "UI/WindowsContainer")]
  public class WindowsContainer : ScriptableObject
  {
    [SerializeField] private List<WindowConfig> _configs;

    private Dictionary<WindowId, WindowConfig> _map = new Dictionary<WindowId, WindowConfig>();

    private void OnEnable()
    {
      if (_map != null)
        _map = _configs.ToDictionary(x => x.WindowId, x => x);
    }

    private void OnValidate()
    {
      if (_configs == null)
        return;

      foreach (WindowConfig windowConfig in _configs)
        windowConfig.Name = windowConfig.WindowId.ToString();
    }

    public WindowConfig Config(WindowId windowId) =>
      _map.ContainsKey(windowId) ? _map[windowId] : null;
  }
}
