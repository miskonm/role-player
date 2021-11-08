using Course.Managers.InputManager.Source;

namespace Course.Managers.InputManager
{
    public interface IInputManager
    {
        IInputSource InputForPlayer(int playerIndex);

        bool InputOverridenForPlayer(int playerIndex);
        void OverrideInputForPlayer(int playerIndex, IInputSource overrideSource);
    }
}
