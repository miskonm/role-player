using Course.Combat;

namespace Course.Managers.PlayerManager.Callbacks
{
    public interface IOnPlayerHealed
    {
        void Do(int playerIndex, IAttacker attacker, float amount, float newHealth);
    }
}
