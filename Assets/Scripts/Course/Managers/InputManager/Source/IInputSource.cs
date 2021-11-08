using Course.Managers.InputManager.Action;

namespace Course.Managers.InputManager.Source
{
    public interface IInputSource
    {
        IInputAction Action(string name);
        void DisconnectAllActions();
    }
}
