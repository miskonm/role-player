using Course.Base;
using Course.Character;
using Course.Character.Callbacks;
using Course.Combat;
using Zenject;

namespace Course.Managers.PlayerManager
{
    public sealed class Player : AbstractService<IPlayer>, IPlayer, IOnCharacterHealed, IOnCharacterDamaged, IOnCharacterDied
    {
        int index = -1;
        public int Index => index;

        [InjectOptional] ICharacterHealth health = default;
        public ICharacterHealth Health => health;

        [Inject] IPlayerManager playerManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (health != null) {
                Observe(health.OnHealed);
                Observe(health.OnDamaged);
                Observe(health.OnDied);
            }

            playerManager.AddPlayer(this, out index);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            playerManager.RemovePlayer(this);
            index = -1;
        }

        void IOnCharacterHealed.Do(ICharacterHealth health, IAttacker attacker, float amount, float newHealth)
        {
            foreach (var it in playerManager.OnPlayerHealed.Enumerate())
                it.Do(index, attacker, amount, newHealth);
        }

        void IOnCharacterDamaged.Do(ICharacterHealth health, IAttacker attacker, float amount, float newHealth)
        {
            foreach (var it in playerManager.OnPlayerDamaged.Enumerate())
                it.Do(index, attacker, amount, newHealth);
        }

        void IOnCharacterDied.Do(ICharacterHealth health, IAttacker attacker)
        {
            foreach (var it in playerManager.OnPlayerDied.Enumerate())
                it.Do(index, attacker);
        }
    }
}
