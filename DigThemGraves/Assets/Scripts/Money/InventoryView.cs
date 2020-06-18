using UnityEngine;
using UniRx;

namespace DigThemGraves
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform itemsParent;
        [SerializeField] private ItemSlot[] itemSlots;

        [SerializeField] private Inventory inventory;

        private void Awake()
        {
            // TODO: RefreshUI won't work if an item changes but count stays the same
            inventory.Items.ObserveCountChanged().Subscribe(_ => RefreshUI());
        }

        private void OnValidate()
        {
            if (itemsParent != null)
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        public void RefreshUI()
        {
            int i = 0;

            for (; i < inventory.Items.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = inventory.Items[i];
            }

            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
            }
        }

    }
}