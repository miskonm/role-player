using Course.Base;
using Course.Managers.InputManager;
using Course.Managers.PlayerManager;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using Zenject;

namespace Course.Managers.SceneStateManager.Utility
{
    public sealed class PushStateOnKeyPress : AbstractBehaviour, IOnUpdate
    {
        public string InputActionName;
        public SceneState State;

        [Inject] IPlayer player = default;
        [Inject] IInputManager inputManager = default;
        [Inject] ISceneState sceneState = default;
        [Inject] ISceneStateManager sceneStateManager = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(sceneState.OnUpdate);
        }

        void IOnUpdate.Do(float timeDelta)
        {
            var input = inputManager.InputForPlayer(player.Index);
            if (input.Action(InputActionName).Triggered)
                sceneStateManager.Push(State);
        }
    }
}
