using RolePlayer.Game.Input;
using UnityEngine;
using Zenject;

namespace RolePlayer.Game.Player
{
  public class PlayerMove : MonoBehaviour
  {
    private const float Epsilon = 0.001f;

    public CharacterController Controller;
    public float MoveSpeed;

    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
      _inputService = inputService;
    }

    private void Update()
    {
      Vector3 moveVector = Vector3.zero;
      Vector2 axis = _inputService.Axis;

      if (axis.sqrMagnitude >= Epsilon)
      {
        moveVector = axis;
        moveVector.Normalize();
      }

      Controller.Move(moveVector * MoveSpeed * Time.deltaTime);
    }
  }
}
