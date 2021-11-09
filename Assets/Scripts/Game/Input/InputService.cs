using UnityEngine;

namespace RolePlayer.Game.Input
{
  public class InputService : IInputService
  {
    public Vector3 Axis =>
      new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));
  }
}
