using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace DigThemGraves
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryModel model;

        [SerializeField]
        private InventoryView view;

        public ItemInstance GetItemAt(int i) => model.items[i];
        public ReactiveCollection<ItemInstance> GetItems => model.items;

        private void Awake()
        {
            model = new InventoryModel();
        }

        public bool AddItem(ItemTemplate item)
        {
            if (model.AddItem(item))
            {
                RefreshUI();
                return true;
            }

            return false;
        }

        public bool RemoveItem(ItemInstance item)
        {
            if (model.RemoveItem(item))
            {
                RefreshUI();
                return true;
            }

            return false;
        }

        public void RefreshUI()
        {
            view.RefreshUI();
        }
    }
}