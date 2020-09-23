using System;
using UniRx;

namespace DigThemGraves
{
    public interface IInventory
    {
        IObservable<ItemInstance> AddedItemsAsObservable();
        IObservable<ItemInstance> RemovedItemsAsObservable();
        IObservable<int> ItemsCountAsObservable();

        void AddItem(ItemTemplate item);
        bool RemoveItem(ItemInstance item);
        int ItemsCount();
    }

    public class Inventory : IInventory
    {
        public ReactiveCollection<ItemInstance> items = new ReactiveCollection<ItemInstance>();

        public IObservable<ItemInstance> AddedItemsAsObservable()
        {
            return items.ObserveAdd().Select(i => i.Value);
        }

        public IObservable<ItemInstance> RemovedItemsAsObservable()
        {
            return items.ObserveRemove().Select(i => i.Value);
        }

        public IObservable<int> ItemsCountAsObservable()
        {
            return items.ObserveCountChanged().Select(i => i);
        }

        public void AddItem(ItemTemplate item)
        {
            items.Add(new ItemInstance(item));
        }

        public bool RemoveItem(ItemInstance item)
        {
            return items.Remove(item);
        }

        public int ItemsCount()
        {
            return items.Count;
        }
    }
}