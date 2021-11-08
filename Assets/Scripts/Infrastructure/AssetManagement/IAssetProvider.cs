using UnityEngine;

namespace RolePlayer.Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    T Load<T>(string path) where T : Object;
    GameObject Instantiate(string path);
  }
}
