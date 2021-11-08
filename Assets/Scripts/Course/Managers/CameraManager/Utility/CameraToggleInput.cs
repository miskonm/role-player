using Course.Base;
using Course.Managers.InputManager;
using Course.Managers.PlayerManager;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using Zenject;

namespace Course.Managers.CameraManager.Utility
{
    public sealed class CameraToggleInput : AbstractBehaviour, IOnUpdate
    {
        public string InputActionName;

        [Inject] IPlayer player = default;
        [Inject] IInputManager inputManager = default;
        [Inject] ICameraManager cameraManager = default;
        [Inject] ISceneState sceneState = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(sceneState.OnUpdate);
        }

        void IOnUpdate.Do(float timeDelta)
        {
            var input = inputManager.InputForPlayer(player.Index);
            if (input.Action(InputActionName).Triggered)
                cameraManager.ToggleFirstThirdPersonCamera(player.Index);
        }
    }
}
