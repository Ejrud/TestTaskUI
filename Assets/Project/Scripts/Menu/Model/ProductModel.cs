using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ProductModel : Model
{
    public ProductModel(View view, ModelData data) : base(data, view) { }
    public Button PurchaseButton => _purchaseButton;
    
    private Button _purchaseButton;
    
    public override void OpenWindow()
    {
        OnSelected?.Invoke(this);
        _view.UpdateView(this);
        _view.SetActiveView(true);
    }

    public override void CloseWindow()
    {
        OnRejected?.Invoke(this);
        _view.ClearView();
        _view.SetActiveView(false);
    }

    public void SetPurchaseButton(Button button)
    {
        _purchaseButton = button;
    }
}
