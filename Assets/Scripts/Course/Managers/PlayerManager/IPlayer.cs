using Course.Character;

namespace Course.Managers.PlayerManager
{
    public interface IPlayer
    {
        int Index { get; }
        ICharacterHealth Health { get; }
    }
}
