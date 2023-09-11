using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
    [SerializeField] private Button _openProductCreator;

    [Header("ItemTypes")] 
    [SerializeField] private ItemType[] _itemTypes;
    
    [Space(10)]
    [SerializeField] private ProductInputView _productInputView;

    [SerializeField] private EntryPoint _entryPoint;
    private Dictionary<string, ItemType> _typeMap;
    private string falseDiscount;

    public override void Init()
    {
        _typeMap = CreateTypeMap();
        _productInputView.Init(_itemTypes);
        falseDiscount = _discount.options[0].text;
        
        _closeButton.onClick.AddListener(() => { _formWindowObj.SetActive(false); });
        _openProductCreator.onClick.AddListener(() => _formWindowObj.SetActive(true));
        _clearFormButton.onClick.AddListener(ClearFields);
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
        {
            LogMessage("Empty field \"Header\"");
            return;
        }

        if (string.IsNullOrWhiteSpace(_description.text))
        {
            LogMessage("Empty field \"Description\"");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(_price.text))
        {
            LogMessage("Empty field \"Price\"");
            return;
        }
        
        if (_productInputView.IsItemsEmpty())
        {
            LogMessage("Empty field \"Items\"");
            return;
        }
        
        CreateProduct();
    }

    private void CreateProduct()
    {
        bool hasDiscount = !string.Equals(_discount.captionText, falseDiscount);

        ProductData productData = new ProductData();
        productData.iconName = _header.text;
        productData.price = float.Parse(_price.text);
        productData.header = _header.text;
        productData.hasDiscount = hasDiscount;
        productData.description = _description.text;
        productData.discountPercentage = (string.IsNullOrWhiteSpace(_percentage.text)) ? 0 : float.Parse(_percentage.text);
        productData.items = GetItems();
        
        _entryPoint.CreateProductModel(productData);
        ClearFields();
    }

    private void ClearFields()
    {
        _productInputView.ClearItems();
        
        _header.text = "";
        _description.text = "";
        _price.text = "";
        _percentage.text = "";
    }


    private List<ItemStack> GetItems()
    {
        List<ItemStack> itemStacks = new List<ItemStack>();

        foreach (var inputFrame in _productInputView.ItemInputFrames)
        {
            if (!inputFrame.isCreated)
                continue;
            
            ItemStack itemStack = new ItemStack();
            itemStack.name = inputFrame.itemName + "Stack";
            itemStack.count = int.Parse(inputFrame.value);
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

    private void LogMessage(string msg)
    {
        Debug.LogWarning(msg);
    }
}
