using TMPro;
using Zenject;

namespace Course.Managers.NotificationManager
{
    public sealed class NotificationMessageFactory : MonoInstaller
    {
        public int PoolSize = 16;
        public TextMeshProUGUI Prefab;

        public override void InstallBindings()
        {
            Container.BindFactory<string, NotificationMessage, NotificationMessage.Factory>()
                .FromMonoPoolableMemoryPool<string, NotificationMessage>(opts => opts
                    .WithInitialSize(PoolSize)
                    .FromComponentInNewPrefab(Prefab)
                    .UnderTransform(transform));
        }
    }
}
