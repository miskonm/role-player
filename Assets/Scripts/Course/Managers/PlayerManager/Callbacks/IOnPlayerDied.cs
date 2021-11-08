using Course.Combat;

namespace Course.Managers.PlayerManager.Callbacks
{
    public interface IOnPlayerDied
    {
        void Do(int playerIndex, IAttacker attacker);
    }
}
