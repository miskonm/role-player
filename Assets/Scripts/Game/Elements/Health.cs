using Course.Base;
using Course.Observers;

namespace RolePlayer.Game.Elements
{
  public class Health : AbstractBehaviour
  {
    public int Current;
    public int Max;

    public ObserverList<IHealthChanged> OnHealthChanged { get; } = new ObserverList<IHealthChanged>();

    public void DoDamage(int damage)
    {
      Current -= damage;

      NotifyHealthChanged();
    }

    private void NotifyHealthChanged()
    {
      foreach (IHealthChanged it in OnHealthChanged.Enumerate())
        it.Do();
    }
  }
}
