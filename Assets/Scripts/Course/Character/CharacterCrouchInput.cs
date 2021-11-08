using Course.Attributes;
using Course.Base;
using Course.Managers.InputManager;
using Course.Managers.PlayerManager;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using UnityEngine;
using Zenject;

namespace Course.Character
{
    public sealed class CharacterCrouchInput : AbstractService<ICharacterCrouchInput>, ICharacterCrouchInput, IOnUpdate
    {
        public string InputActionName;
        public CapsuleCollider CrouchCollider;
        public CapsuleCollider FullCollider;

        [SerializeField] [ReadOnly] bool crouching;
        public bool Crouching => crouching;

        [Inject] IPlayer player = default;
        [Inject] IInputManager inputManager = default;
        [Inject] ISceneState sceneState = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(sceneState.OnUpdate);
        }

        void IOnUpdate.Do(float timeDelta)
        {
            var input = inputManager.InputForPlayer(player.Index);
            if (input.Action(InputActionName).Triggered) {
                crouching = !crouching;
                CrouchCollider.enabled = crouching;
                FullCollider.enabled = !crouching;
            }
        }
    }
}
