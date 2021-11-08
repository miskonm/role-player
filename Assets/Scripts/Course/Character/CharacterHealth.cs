using Course.Base;
using Course.Character.Callbacks;
using Course.Combat;
using Course.Observers;
using Course.Utility;
using UnityEngine;

namespace Course.Character
{
    public sealed class CharacterHealth : AbstractService<ICharacterHealth>, ICharacterHealth
    {
        [SerializeField] float health;
        public float Health => health;

        [SerializeField] float maxHealth;
        public float MaxHealth => maxHealth;

        public ObserverList<IOnCharacterDamaged> OnDamaged { get; } = new ObserverList<IOnCharacterDamaged>();
        public ObserverList<IOnCharacterDied> OnDied { get; } = new ObserverList<IOnCharacterDied>();
        public ObserverList<IOnCharacterHealed> OnHealed { get; } = new ObserverList<IOnCharacterHealed>();

        public void Damage(IAttacker attacker, float damage)
        {
            DebugOnly.Check(damage >= 0.0f, "Damage is negative.");
            health -= damage;

            bool died = false;
            if (health <= 0.0f) {
                health = 0.0f;
                died = true;
            }

            foreach (var it in OnDamaged.Enumerate())
                it.Do(this, attacker, damage, health);

            if (died) {
                foreach (var it in OnDied.Enumerate())
                    it.Do(this, attacker);
            }
        }

        public void Heal(IAttacker attacker, float heal)
        {
            DebugOnly.Check(heal >= 0.0f, "Heal is negative.");

            health += heal;
            if (health > MaxHealth)
                health = MaxHealth;

            foreach (var it in OnHealed.Enumerate())
                it.Do(this, attacker, heal, health);
        }
    }
}
