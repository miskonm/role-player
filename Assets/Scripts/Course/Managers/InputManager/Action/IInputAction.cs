using UnityEngine;

namespace Course.Managers.InputManager.Action
{
    public interface IInputAction
    {
        bool Triggered { get; }
        bool Active { get; }
        Vector2 Vector2Value { get; }
    }
}
