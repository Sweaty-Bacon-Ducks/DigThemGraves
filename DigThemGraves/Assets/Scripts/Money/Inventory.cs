using UnityEngine;
using UniRx;

namespace DigThemGraves
{
    public class Inventory : MonoBehaviour
    {
        public ReactiveCollection<ItemInstance> Items = new ReactiveCollection<ItemInstance>();

        public MoneyPresenter Money;

        private readonly int itemSlots = 16;

        public bool IsFull { get => Items.Count >= itemSlots; }

        public bool AddItem(ItemTemplate item)
        {
            if (IsFull)
                return false;

            Items.Add(new ItemInstance(item));
            return true;
        }

        public bool RemoveItem(ItemInstance item)
        {
            if (Items.Remove(item))
            {
                return true;
            }
            return false;
        }
    }
}