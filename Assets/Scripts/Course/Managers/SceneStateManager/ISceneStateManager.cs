using Course.Managers.SceneStateManager.State;

namespace Course.Managers.SceneStateManager
{
    public interface ISceneStateManager
    {
        ISceneState CurrentState { get; }
        void Push(ISceneState state);
        void Pop(ISceneState state);
    }
}
