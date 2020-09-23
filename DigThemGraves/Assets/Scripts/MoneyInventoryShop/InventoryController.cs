using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace DigThemGraves
{
    public class InventoryController : MonoBehaviour, IController<Inventory>
    {
        private Inventory model;
        public Inventory Model => model;

        [SerializeField]
        private InventoryView view;

        public ItemInstance GetItemAt(int i) => Model.items[i];
        public List<ItemInstance> GetItems => Model.items.ToList();

        private void Awake()
        {
            model = new Inventory();
        }

        public void AddItem(ItemTemplate item)
        {
            Model.AddItem(item);
        }

        public bool RemoveItem(ItemInstance item)
        {
            if (Model.RemoveItem(item))
            {
                return true;
            }

            return false;
        }
    }
}