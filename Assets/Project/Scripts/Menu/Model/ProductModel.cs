using System;
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
        _view.gameObject.SetActive(true);
        _view.UpdateView(this);
    }

    public override void CloseWindow()
    {
        OnRejected?.Invoke(this);
        _view.gameObject.SetActive(false);
        _view.ClearView();
    }

    public void SetPurchaseButton(Button button)
    {
        _purchaseButton = button;
    }
}
