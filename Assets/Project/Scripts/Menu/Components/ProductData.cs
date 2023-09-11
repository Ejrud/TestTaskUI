using System;
using System.Collections.Generic;

[Serializable]
public struct ProductData
{
    // Можно создать отдельную модель с дополнительным полем "DiscountPrice", 
    // но так я думаю будет проще и лучше
    public string iconName;
    public float price;
    public string header;
    public bool hasDiscount;
    public string description;
    public float discountPercentage;
    public List<ItemStack> items;

}
