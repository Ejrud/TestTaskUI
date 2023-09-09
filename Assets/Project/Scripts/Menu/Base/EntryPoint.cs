using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<PackConfig> _donateConfigs;
    
    [Header("UI")]
    [SerializeField] private ProductView _productView;
    [SerializeField] private ProductDiscountView _productDiscountView;

    [Header("Controllers")]
    [SerializeField] private PurchaseController _purchaseController;
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
        _productAreaController.Init();
        foreach (var model in models)
        {
            _productAreaController.AddModel(model);
        }
    }

    private void InitPurchaseController(List<Model> models)
    {
        _purchaseController.Init();
        foreach (var model in models)
        {
            _purchaseController.AddModel(model);
        }
    }
}
