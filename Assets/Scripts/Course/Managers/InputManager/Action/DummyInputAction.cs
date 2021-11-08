using UnityEngine;

namespace Course.Managers.InputManager.Action
{
    public sealed class DummyInputAction : IInputAction
    {
        public static readonly DummyInputAction Instance = new DummyInputAction();

        public bool Active => false;
        public bool Triggered => false;
        public Vector2 Vector2Value => Vector2.zero;
    }
}
