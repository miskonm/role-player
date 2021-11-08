using Course.Base;
using Course.Managers.ExperienceManager.Callbacks;
using Course.Managers.LocalizationManager;
using Course.Managers.NotificationManager;
using Zenject;

namespace Course.Managers.ExperienceManager.Utility
{
    public sealed class ExperienceNotification : AbstractBehaviour, IOnExperienceGained
    {
        public int PlayerIndex;
        public LocalizedString Message;

        [Inject] ILocalizationManager localizationManager = default;
        [Inject] INotificationManager notificationManager = default;
        [Inject] IExperienceManager experienceManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(experienceManager.OnExperienceGained);
        }

        void IOnExperienceGained.Do(int player, int experience)
        {
            if (PlayerIndex == player)
                notificationManager.DisplayMessage(string.Format(localizationManager.GetString(Message), experience));
        }
    }
}
