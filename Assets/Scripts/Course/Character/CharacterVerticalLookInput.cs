using Course.Base;
using Course.Managers.InputManager;
using Course.Managers.PlayerManager;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using UnityEngine;
using Zenject;

namespace Course.Character
{
    public sealed class CharacterVerticalLookInput : AbstractBehaviour, IOnUpdate
    {
        public string InputActionName;
        public Transform EyesTransform;
        public float RotationSpeed;
        public float MinVerticalAngle = -50.0f;
        public float MaxVerticalAngle = 50.0f;

        [Inject] IPlayer player = default;
        [Inject] IInputManager inputManager = default;
        [Inject] ISceneState sceneState = default;

        float angle;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(sceneState.OnUpdate);
        }

        void IOnUpdate.Do(float timeDelta)
        {
            var input = inputManager.InputForPlayer(player.Index);
            var dir = input.Action(InputActionName).Vector2Value;

            if (!Mathf.Approximately(dir.y, 0.0f)) {
                angle += dir.y * RotationSpeed * timeDelta;
                angle = Mathf.Clamp(angle, MinVerticalAngle, MaxVerticalAngle);

                var angles = EyesTransform.localEulerAngles;
                angles.x = angle;
                EyesTransform.localEulerAngles = angles;
            }
        }
    }
}
