using UnityEngine;

namespace RolePlayer.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public T Load<T>(string path) where T : Object =>
      Resources.Load<T>(path);

    public GameObject Instantiate(string path)
    {
      var prefab = Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }
  }
}
