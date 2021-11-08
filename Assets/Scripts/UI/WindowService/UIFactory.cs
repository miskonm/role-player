using RolePlayer.Infrastructure.AssetManagement;
using RolePlayer.UI.WindowService.Windows;
using UnityEngine;
using Zenject;

namespace RolePlayer.UI.WindowService
{
  public class UIFactory : IUIFactory
  {
    private readonly DiContainer _diContainer;
    private readonly WindowsContainer _windowsContainer;
    private readonly Transform _uiRoot;
    
    public UIFactory(DiContainer diContainer, IAssetProvider assetProvider)
    {
      _diContainer = diContainer;
      _uiRoot = assetProvider.Instantiate(AssetPath.UiRoot).transform;
      _windowsContainer = assetProvider.Load<WindowsContainer>(AssetPath.WindowsContainer);
    }

    public BaseWindow Create(WindowId windowId)
    {
      WindowConfig config = _windowsContainer.Config(windowId);
      return _diContainer.InstantiatePrefabForComponent<BaseWindow>(config.Prefab, _uiRoot);
    }
  }
}
