using Course.Managers.PlayerManager.Callbacks;
using Course.Observers;

namespace Course.Managers.PlayerManager
{
    public interface IPlayerManager
    {
        int NumPlayers { get; }

        ObserverList<IOnPlayerAdded> OnPlayerAdded { get; }
        ObserverList<IOnPlayerRemoved> OnPlayerRemoved { get; }

        ObserverList<IOnPlayerDamaged> OnPlayerDamaged { get; }
        ObserverList<IOnPlayerDied> OnPlayerDied { get; }
        ObserverList<IOnPlayerHealed> OnPlayerHealed { get; }

        void AddPlayer(IPlayer player, out int index, bool reuseSlots = true);
        void RemovePlayer(IPlayer player);

        IPlayer GetPlayer(int index);
    }
}
