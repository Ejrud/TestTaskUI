using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<PackConfig> _donateConfigs;
    
    [Header("UI")]
    [SerializeField] private ProductView _productView;
    [SerializeField] private ProductDiscountView _productDiscountView;

    [Header("Buttons")] 
    [SerializeField] private Transform _productAreaParent;
    [SerializeField] private GameObject _productWindowObj;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private Button _closeButton;

    [Header("Controllers")]
    [SerializeField] private ProductPurchaseController _productPurchaseController;
    [SerializeField] private ProductAreaController _productAreaController;
    
    private void Start()
    {
        List<Model> productModels = new List<Model>();
        
        foreach (var config in _donateConfigs)
        {
            Model model = (config.Data.HasDiscount) ? 
                new ProductModel(_productDiscountView, config.Data) : 
                new ProductModel(_productView, config.Data);
            
            productModels.Add(model);
        }

        InitProductAreaController(productModels);
        InitPurchaseController(productModels);
    }
    
    private void InitProductAreaController(List<Model> models)
    {
        _productAreaController.Init(_productWindowObj, _productAreaParent, _closeButton);
        foreach (var model in models)
        {
            _productAreaController.AddModel(model);
        }
    }

    private void InitPurchaseController(List<Model> models)
    {
        _productPurchaseController.Init(_purchaseButton);
        foreach (var model in models)
        {
            _productPurchaseController.AddModel(model);
        }
    }
}
