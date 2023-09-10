using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PurchaseController : Controller
{
    [SerializeField] private Button _purchaseButton;

    public override void Init()
    {
        // За все время не видел что бы где то, кто то отписывался от события нажатия на кнопку,
        // но я на всякий случай добавлю эту возможность.
        _purchaseButton.onClick.AddListener(Purchase);
    }

    public void Purchase()
    {
        if (_currentModel == null)
        {
            Debug.Log("No model selected for purchase");
            return;
        }
        
        // TODO Some action
        Debug.Log($"You have purchased {_currentModel.Data.iconName}");
    }

    public override void Dispose()
    {
        base.Dispose();
        _purchaseButton.onClick.RemoveListener(Purchase);
    }
}