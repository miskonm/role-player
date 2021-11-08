using Course.Base;

namespace Course.Combat
{
    public abstract class AbstractWeaponAttack : AbstractBehaviour, IWeaponAttack
    {
        public abstract void BeginAttack(float damage);
        public abstract void EndAttack();
    }
}
