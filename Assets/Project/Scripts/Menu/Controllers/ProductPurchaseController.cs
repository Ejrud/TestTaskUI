using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ProductPurchaseController : Controller
{
    // ProductInputController отвечает за нажатие кнопки покупки.
    // Ссылки на кнопки нужно передать после инициализации всех
    // моделей с данными о товаре

    private Button _purchaseButton;
    private Model _currentModel;

    public void Init(Button purchaseButton)
    {
        // За все время не видел что бы где то, кто то отписывался от события нажатия на кнопку,
        // но я на всякий случай добавлю эту возможность.
        _purchaseButton = purchaseButton;
        _purchaseButton.onClick.AddListener(Purchase);
       
    }
    
    public override void AddModel(Model model)
    {
        _models.Add(model);
        model.OnSelected += SelectedModel;
    }

    public void Purchase()
    {
        if (_currentModel == null)
        {
            Debug.Log("No model selected for purchase");
            return;
        }
        
        // TODO Some action
        Debug.Log($"You have purchased {_currentModel.Data.IconName}");
    }

    public void Dispose()
    {
        _purchaseButton.onClick.RemoveListener(Purchase);
        
        foreach (var model in _models)
        {
            model.OnSelected -= SelectedModel;
        }
    }

    private void SelectedModel(Model selecterModel)
    {
        Debug.Log($"Model selected {selecterModel.Data.IconName}");
        _currentModel = selecterModel;
    }
}