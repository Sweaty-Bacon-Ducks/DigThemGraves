using UnityEngine;
using UniRx;
using System;

namespace DigThemGraves
{
    public class InventoryModel
    {
        public ReactiveCollection<ItemInstance> items = new ReactiveCollection<ItemInstance>();

        //public IObservable<ItemInstance> ItemsAsObservable => items.AsObservable();
        //public IObservable<ItemInstance> Items
        //{
        //    get
        //    {
        //        return items.ToObservable();
        //    }
        //}

        public bool AddItem(ItemTemplate item)
        {
            items.Add(new ItemInstance(item));
            return true;
        }

        public bool RemoveItem(ItemInstance item)
        {
            if (items.Remove(item))
            {
                return true;
            }
            return false;
        }
    }
}