using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModelData
{
    // Можно создать отдельную модель с дополнительным полем "DiscountPrice", 
    // но так я думаю будет проще и лучше
    public string IconName => _iconName;
    public float Price => _price;
    public string Header => _header;
    public bool HasDiscount => _hasDiscount;
    public string Description => _description;
    public float DiscountPercentage => _discountPercentage;
    public List<ItemStack> Items => _items;


    [SerializeField] protected string _iconName;
    [SerializeField] protected bool _hasDiscount;
    [SerializeField] protected string _header;
    [SerializeField] protected string _description;
    [SerializeField] protected float _price;
    [SerializeField] protected float _discountPercentage;
    [SerializeField] protected List<ItemStack> _items;
}
