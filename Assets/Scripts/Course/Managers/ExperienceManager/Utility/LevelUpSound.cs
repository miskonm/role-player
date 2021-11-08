using Course.Base;
using Course.Managers.ExperienceManager.Callbacks;
using Course.Managers.SoundManager;
using UnityEngine;
using Zenject;

namespace Course.Managers.ExperienceManager.Utility
{
    public sealed class LevelUpSound : AbstractBehaviour, IOnLevelReached
    {
        public int PlayerIndex;
        public AudioClip sound;

        [Inject] ISoundManager soundManager = default;
        [Inject] IExperienceManager experienceManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(experienceManager.OnLevelReached);
        }

        void IOnLevelReached.Do(int player, int level)
        {
            if (PlayerIndex == player)
                soundManager.Sfx.Play(sound);
        }
    }
}
