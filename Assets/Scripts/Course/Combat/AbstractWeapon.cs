using Course.Inventory;
using UnityEngine;

namespace Course.Combat
{
    public abstract class AbstractWeapon : ScriptableObject
    {
        public AbstractInventoryItem InventoryItem;
        
        public float AttackCooldownTime;

        public virtual bool CanShoot(IInventoryStorage inventory)
        {
            return true;
        }

        public virtual bool PrepareShoot(IInventoryStorage inventory, IWeaponAttack attack)
        {
            return true;
        }

        public virtual void EndShoot(IWeaponAttack attack)
        {
            attack.EndAttack();
        }
    }
}
