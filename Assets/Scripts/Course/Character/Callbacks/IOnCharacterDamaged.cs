using Course.Combat;

namespace Course.Character.Callbacks
{
    public interface IOnCharacterDamaged
    {
        void Do(ICharacterHealth health, IAttacker attacker, float amount, float newHealth);
    }
}
