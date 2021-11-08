using Course.Base;
using Course.Managers.ExperienceManager.Callbacks;
using Course.Managers.LocalizationManager;
using Course.Managers.NotificationManager;
using Zenject;

namespace Course.Managers.ExperienceManager.Utility
{
    public sealed class LevelUpNotification : AbstractBehaviour, IOnLevelReached
    {
        public int PlayerIndex;
        public LocalizedString Message;

        [Inject] ILocalizationManager localizationManager = default;
        [Inject] INotificationManager notificationManager = default;
        [Inject] IExperienceManager experienceManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(experienceManager.OnLevelReached);
        }

        void IOnLevelReached.Do(int player, int level)
        {
            if (PlayerIndex == player)
                notificationManager.DisplayMessage(localizationManager.GetString(Message));
        }
    }
}
