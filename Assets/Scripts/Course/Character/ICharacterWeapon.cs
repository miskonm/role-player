using Course.Character.Callbacks;
using Course.Combat;
using Course.Observers;

namespace Course.Character
{
    public interface ICharacterWeapon
    {
        AbstractWeapon CurrentWeapon { get; }
        AbstractWeapon AttackingWeapon { get; }
        ObserverList<IOnCharacterAttack> OnAttack { get; }
        void SetCurrentWeapon(AbstractWeapon weapon);
        bool CanAttack();
        void Attack();
        void EndAttack(bool applyCooldown);
    }
}
