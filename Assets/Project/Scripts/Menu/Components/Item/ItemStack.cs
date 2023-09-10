using System;

[Serializable]
public struct ItemStack
{
    public string name;
    public int count;
    public Item item;

    public bool AddItem(Item item, int count = 1)
    {
        if (this.item.type != item.type)
        {
            return false;
        }

        this.count += count;
        return true;
    }

    public ItemType GetItemType()
    {
        return item.type;
    }
}
