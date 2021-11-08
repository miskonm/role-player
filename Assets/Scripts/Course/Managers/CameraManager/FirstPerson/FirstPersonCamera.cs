using Course.Base;
using Course.Managers.PlayerManager;
using UnityEngine;
using Zenject;

namespace Course.Managers.CameraManager.FirstPerson
{
    public sealed class FirstPersonCamera : AbstractBehaviour, IFirstPersonCamera
    {
        [Inject] IPlayer player = default;
        [Inject] ICameraManager cameraManager = default;

        public int PlayerIndex => player.Index;
        public GameObject GameObject => gameObject;

        void Awake()
        {
            cameraManager.AddFirstPersonCamera(this);
        }

        void OnDestroy()
        {
            cameraManager.RemoveFirstPersonCamera(this);
        }
    }
}
