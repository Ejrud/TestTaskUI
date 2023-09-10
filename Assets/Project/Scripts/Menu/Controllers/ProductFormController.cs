using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ProductFormController : Controller
{
    [Header("UI")] 
    [SerializeField] private GameObject _formWindowObj;
    [SerializeField] private TMP_InputField _header;
    [SerializeField] private TMP_InputField _description;
    [SerializeField] private TMP_InputField _price;
    [SerializeField] private TMP_Dropdown _discount;
    [SerializeField] private TMP_InputField _percentage;
    
    [Header("Buttons")]
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _clearFormButton;

    [Header("ItemTypes")] 
    [SerializeField] private ItemType[] _itemTypes;
    
    [Space(10)]
    [SerializeField] private ProductInputView _productInputView;

    private Dictionary<string, ItemType> _typeMap;
    private string falseDiscount;

    public override void Init()
    {
        _typeMap = CreateTypeMap();
        _productInputView.Init(_itemTypes);
        falseDiscount = _discount.options[0].text;
        
        _closeButton.onClick.AddListener(() => { _formWindowObj.SetActive(false); });
        _clearFormButton.onClick.AddListener(_productInputView.ClearItems);
        _createButton.onClick.AddListener(PrepareProduct);
        _addButton.onClick.AddListener(AddItem);
    }

    private void AddItem()
    {
        if (_productInputView.IsExceededLimit())
        {
            Debug.Log("Maximum number of items exceeded");
            return;
        }
        
        _productInputView.OpenItemInputFrame();
    }

    private void PrepareProduct()
    {
        if (string.IsNullOrWhiteSpace(_header.text))
            return; 
        
        if (string.IsNullOrWhiteSpace(_description.text))
            return; 
        
        if (string.IsNullOrWhiteSpace(_price.text))
            return;
        
        if (_productInputView.IsEmptyFields())
            return;
        
        CreateProduct();
    }

    private void CreateProduct()
    {
        bool hasDiscount = !string.Equals(_discount.captionText, falseDiscount);

        ProductData productData = new ProductData();
        productData.iconName = _header.text;
        productData.price = Convert.ToSingle(_price.text);
        productData.header = _header.text;
        productData.hasDiscount = hasDiscount;
        productData.description = _description.text;
        productData.discountPercentage = Convert.ToSingle(_percentage.text);

        List<ItemStack> itemStacks = GetItems();
    }

    
    private List<ItemStack> GetItems()
    {
        List<ItemStack> itemStacks = new List<ItemStack>();

        foreach (var inputFrame in _productInputView.ItemInputFrames)
        {
            ItemStack itemStack = new ItemStack();
            itemStack.name = inputFrame.itemName + "Stack";
            itemStack.count = Convert.ToInt32(inputFrame.value);
            itemStack.item.type = GetItemTypeByString(inputFrame.itemType);
            itemStack.item.description = "";
            itemStack.item.iconName = inputFrame.itemName;
            
            itemStacks.Add(itemStack);
        }

        return itemStacks;
    }

    private ItemType GetItemTypeByString(string typeString)
    {
        ItemType type = ItemType.None;

        if (_typeMap.TryGetValue(typeString, out ItemType itemType))
        {
            return itemType;
        }

        return type;
    }

    private Dictionary<string, ItemType> CreateTypeMap()
    {
        Dictionary<string, ItemType> typeMap = new Dictionary<string, ItemType>();

        foreach (var itemType in _itemTypes)
        {
            string typeString = itemType.ToString();
            typeMap.Add(typeString, itemType);
        }
        
        return typeMap;
    }
}
