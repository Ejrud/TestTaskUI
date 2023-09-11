using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private SpriteLibrary _spriteLibrary;
    [SerializeField] private List<ProductConfig> _productConfigs;
    
    [Header("View")]
    [SerializeField] private ProductView _productView;
    [SerializeField] private ProductDiscountView _productDiscountView;

    [Header("Controllers")]
    [SerializeField] private PurchaseController _purchaseController;
    [SerializeField] private ProductAreaController _productAreaController;
    [SerializeField] private ProductFormController _productFormController;
    
    private void Start()
    {
        _spriteLibrary.Init();
        _purchaseController.Init();
        _productAreaController.Init();
        _productFormController.Init();
        
        foreach (var product in _productConfigs)
        {
            CreateProductModel(product.Data);
        }
    }

    public void CreateProductModel(ProductData data)
    {
        Model model = (data.hasDiscount) ? 
            new ProductModel(_productDiscountView, data) : 
            new ProductModel(_productView, data);
            
        _productAreaController.AddModel(model);
        _purchaseController.AddModel(model);
    }
}
