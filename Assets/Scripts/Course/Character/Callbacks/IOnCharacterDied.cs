using Course.Combat;

namespace Course.Character.Callbacks
{
    public interface IOnCharacterDied
    {
        void Do(ICharacterHealth health, IAttacker attacker);
    }
}
