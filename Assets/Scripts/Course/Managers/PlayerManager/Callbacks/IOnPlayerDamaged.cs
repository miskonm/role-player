using Course.Combat;

namespace Course.Managers.PlayerManager.Callbacks
{
    public interface IOnPlayerDamaged
    {
        void Do(int playerIndex, IAttacker attacker, float amount, float newHealth);
    }
}
