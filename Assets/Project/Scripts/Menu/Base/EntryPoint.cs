using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<PackConfig> _packConfigs;
    
    [Header("UI")]
    [SerializeField] private DonateView _donateView;
    [SerializeField] private DonateDiscountView _donateDiscountView;
    private Controller _controller;
    
    private void Start()
    {
        List<Model> models = new List<Model>();
        
        foreach (var pack in _packConfigs)
        {
            Model model = (pack.Data.HasDiscount) ? 
                new DonateModel(_donateDiscountView, pack.Data) : 
                new DonateModel(_donateView, pack.Data);
            
            models.Add(model);
        }
        
        _controller = new ButtonInputController(models);
        _controller.Init();
    }
}
