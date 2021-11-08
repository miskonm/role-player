using UnityEngine;

namespace Course.Character
{
    public interface ICharacterAgent
    {
        void Move(Vector2 dir);
        void Stop();
    }
}
