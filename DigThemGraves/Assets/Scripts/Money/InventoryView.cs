using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace DigThemGraves
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryController controller;

        [SerializeField] private Transform itemSlotParent;

        [SerializeField] private ItemSlot itemSlotPrefab;

        private List<ItemSlot> itemSlots = new List<ItemSlot>();

        private void Start()
        {
            // TODO: RefreshUI won't work if an item changes but count stays the same
            controller.GetItems.ObserveCountChanged().Subscribe(_ => RefreshUI());
        }

        public void RefreshUI()
        {
            ClearView();

            for (int i = 0; i < controller.GetItems.Count; i++)
            {
                ItemSlot itemSlot = Instantiate(itemSlotPrefab, itemSlotParent);
                itemSlot.Initialize(controller.GetItemAt(i));
                itemSlots.Add(itemSlot);
            }
        }

        private void ClearView()
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                Destroy(itemSlot.gameObject);
            }
            itemSlots.Clear();
        }
    }
}