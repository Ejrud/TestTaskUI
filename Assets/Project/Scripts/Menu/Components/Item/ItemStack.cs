using System;
using UnityEngine;

[Serializable]
public class ItemStack
{
    public string name;
    public int count => _count;
    public Item item => _item;
    
    [SerializeField] private int _count;
    [SerializeField] private Item _item;

    public bool AddItem(Item item, int count = 1)
    {
        if (_item == null)
        {
            _item = item;
            _count = count;
            return true;
        }

        if (_item.Type != item.Type)
        {
            return false;
        }

        _count += count;
        return true;
    }

    public ItemType GetItemType()
    {
        return item.Type;
    }
}
