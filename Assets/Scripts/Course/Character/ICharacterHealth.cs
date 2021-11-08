using Course.Character.Callbacks;
using Course.Combat;
using Course.Observers;

namespace Course.Character
{
    public interface ICharacterHealth
    {
        float Health { get; }
        float MaxHealth { get; }

        ObserverList<IOnCharacterDamaged> OnDamaged { get; }
        ObserverList<IOnCharacterDied> OnDied { get; }
        ObserverList<IOnCharacterHealed> OnHealed { get; }

        void Damage(IAttacker attacker, float damage);
        void Heal(IAttacker attacker, float heal);
    }
}
