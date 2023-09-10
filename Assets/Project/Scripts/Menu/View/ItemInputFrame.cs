using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInputFrame : MonoBehaviour
{
    public bool isCreated => _isCreated;
    public string itemName => _itemName.text;
    public string value => _itemValue.text;
    public string itemType => _itemType.captionText.text; 
    
    [SerializeField] private TMP_InputField _itemName;
    [SerializeField] private TMP_InputField _itemValue;
    [SerializeField] private TMP_Dropdown _itemType;

    private bool _isCreated;

    public void Init(ItemType[] itemTypes)
    {
        _itemType.options = new List<TMP_Dropdown.OptionData>();
        
        foreach (var itemType in itemTypes)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = itemType.ToString();
            _itemType.options.Add(optionData);
        }
    }

    public bool IsEmpty()
    {
        // Проверка на тип "_itemValue" нет смысла, т.к. это не цель текущего тестового задания :)
        if (string.IsNullOrWhiteSpace(_itemName.text) || string.IsNullOrWhiteSpace(_itemValue.text))
            return true;
        
        return false;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        _isCreated = active;
    }
}
