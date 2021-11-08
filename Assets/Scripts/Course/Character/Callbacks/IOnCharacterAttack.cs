using Course.Combat;

namespace Course.Character.Callbacks
{
    public interface IOnCharacterAttack
    {
        void Do(AbstractWeapon weapon);
    }
}
