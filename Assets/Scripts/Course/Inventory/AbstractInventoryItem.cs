using Course.Managers.LocalizationManager;
using UnityEngine;

namespace Course.Inventory
{
    public abstract class AbstractInventoryItem : ScriptableObject
    {
        public AbstractInventoryCategory Category;
        public LocalizedString Title;
        public LocalizedString Description;
        public Sprite Icon;

        public virtual bool LessThan(AbstractInventoryItem other)
        {
            return Title.LocalizationID.CompareTo(other.Title.LocalizationID) < 0;
        }
    }
}
