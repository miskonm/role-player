using System;
using UnityEngine;

namespace RolePlayer.UI.WindowService.Windows
{
  public abstract class BaseWindow : MonoBehaviour
  {
    private Action _onClose;
    
    public void Show() =>
      gameObject.SetActive(true);

    public void Hide() =>
      gameObject.SetActive(false);

    public virtual void Close()
    {
      _onClose?.Invoke();
      Destroy(gameObject);
    }

    public void OnClose(Action onClose) =>
      _onClose = onClose;
  }
}
