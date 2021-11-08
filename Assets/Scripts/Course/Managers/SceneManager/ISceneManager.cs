using Course.Observers;

namespace Course.Managers.SceneManager
{
    public interface ISceneManager
    {
        ObserverList<IOnBeginSceneLoad> OnBeginSceneLoad { get; }
        ObserverList<IOnCurrentSceneUnload> OnCurrentSceneUnload { get; }
        ObserverList<IOnSceneLoadProgress> OnSceneLoadProgress { get; }
        ObserverList<IOnEndSceneLoad> OnEndSceneLoad { get; }

        void LoadSceneAsync(string sceneName);
    }
}
