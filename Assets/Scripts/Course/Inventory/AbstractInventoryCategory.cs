using Course.Managers.LocalizationManager;
using UnityEngine;

namespace Course.Inventory
{
    public abstract class AbstractInventoryCategory : ScriptableObject
    {
        public LocalizedString Name;
    }
}
