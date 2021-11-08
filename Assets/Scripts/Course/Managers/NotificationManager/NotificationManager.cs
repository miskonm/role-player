using Course.Base;
using Zenject;

namespace Course.Managers.NotificationManager
{
    public sealed class NotificationManager : AbstractService<INotificationManager>, INotificationManager
    {
        [Inject] NotificationMessage.Factory messageFactory = default;

        public void DisplayMessage(string message)
        {
            messageFactory.Create(message);
        }
    }
}
