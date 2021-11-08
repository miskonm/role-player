using Course.Managers.PlayerManager;

namespace Course.Combat
{
    public interface IAttacker
    {
        IPlayer Player { get; }
    }
}
