using Course.Character.Callbacks;
using Course.Observers;

namespace Course.Character
{
    public interface ICharacterJumpInput
    {
        ObserverList<IOnCharacterJump> OnCharacterJump { get; }
    }
}
