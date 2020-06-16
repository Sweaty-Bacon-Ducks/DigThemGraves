using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemTemplate> _items = new List<ItemTemplate>();
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private ItemSlot[] _itemSlots;

    private void OnValidate()
    {
        if (_itemsParent != null)
            _itemSlots = _itemsParent.GetComponentsInChildren<ItemSlot>();

        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < _items.Count && i < _itemSlots.Length; i++)
        {
            _itemSlots[i].Item = _items[i];
        }

        for (; i < _itemSlots.Length; i++)
        {
            _itemSlots[i].Item = null;
        }
    }

    public bool AddItem(ItemTemplate item)
    {
        if (IsFull())
            return false;

        _items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(ItemTemplate item)
    {
        if (_items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return _items.Count >= _itemSlots.Length;
    }
}
