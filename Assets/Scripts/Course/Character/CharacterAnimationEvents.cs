using Course.Base;
using Course.Character.Callbacks;
using Course.Observers;

namespace Course.Character
{
    public sealed class CharacterAnimationEvents : AbstractService<CharacterAnimationEvents>
    {
        public readonly ObserverList<IOnAttackAnimationEnded> OnAttackEnded = new ObserverList<IOnAttackAnimationEnded>();

        void AttackEnded()
        {
            foreach (var it in OnAttackEnded.Enumerate())
                it.Do();
        }
    }
}
