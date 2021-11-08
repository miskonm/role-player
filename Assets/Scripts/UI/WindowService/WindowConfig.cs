using System;
using RolePlayer.UI.WindowService.Windows;
using UnityEngine;

namespace RolePlayer.UI.WindowService
{
  [Serializable]
  public class WindowConfig
  {
    [HideInInspector]
    public string Name;
    public WindowId WindowId;
    public BaseWindow Prefab;
  }
}
