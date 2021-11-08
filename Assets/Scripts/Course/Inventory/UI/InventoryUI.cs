using System.Collections.Generic;
using Course.Base;
using Course.Inventory.Callbacks;
using Course.Managers.SceneStateManager.State;
using Course.Managers.SceneStateManager.State.Callbacks;
using Course.Observers;
using UnityEngine;
using Zenject;

namespace Course.Inventory.UI
{
    public sealed class InventoryUI : AbstractBehaviour, IOnStateActivate, IOnStateDeactivate, IOnInventoryChanged
    {
        public AbstractInventory Inventory;
        public Transform Content;
        public int ItemsPerRow = 8;

        readonly List<InventoryRow> rows = new List<InventoryRow>();
        ObserverHandle inventoryChangeObserver;
        [Inject] ISceneState state = default;
        [Inject] InventoryRow.Factory rowFactory = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(state.OnActivate);
            Observe(state.OnDeactivate);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Clear();
        }

        void IOnStateActivate.Do()
        {
            Refresh();
            Observe(ref inventoryChangeObserver, Inventory.RawStorage.OnChanged);
        }

        void IOnStateDeactivate.Do()
        {
            Unobserve(inventoryChangeObserver);
            Clear();
        }

        void IOnInventoryChanged.Do()
        {
            Refresh();
        }

        void Refresh()
        {
            Clear();

            InventoryRow row = null;
            foreach (var it in Inventory.RawStorage.RawItems) {
                if (row == null || row.Count >= ItemsPerRow) {
                    row = rowFactory.Create();
                    row.transform.SetParent(Content, false);
                    rows.Add(row);
                }

                row.AddItem(it.item, it.count);
            }
        }

        void Clear()
        {
            foreach (var row in rows)
                row.Pool.Despawn(row);
            rows.Clear();
        }
    }
}
