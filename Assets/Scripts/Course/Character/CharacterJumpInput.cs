using Course.Base;
using Course.Character.Callbacks;
using Course.Managers.InputManager;
using Course.Managers.PlayerManager;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using Course.Observers;
using Zenject;

namespace Course.Character
{
    public sealed class CharacterJumpInput : AbstractService<ICharacterJumpInput>, ICharacterJumpInput, IOnUpdate
    {
        public string InputActionName;

        public ObserverList<IOnCharacterJump> OnCharacterJump { get; } = new ObserverList<IOnCharacterJump>();

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
                

                foreach (var observer in OnCharacterJump.Enumerate())
                    observer.Do();
            }
        }
    }
}
