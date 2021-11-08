using Course.Base;
using Course.Character.Callbacks;
using Course.Combat;
using Course.Managers.ExperienceManager;
using Zenject;

namespace Course.Character
{
    public class CharacterGivesExperience : AbstractBehaviour, IOnCharacterDied
    {
        public int Experience;

        [Inject] ICharacterHealth health = default;
        [Inject] IExperienceManager experienceManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(health.OnDied);
        }

        void IOnCharacterDied.Do(ICharacterHealth health, IAttacker attacker)
        {
            if (attacker.Player != null)
                experienceManager.AddExperience(attacker.Player.Index, Experience);
        }
    }
}
