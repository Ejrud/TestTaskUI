using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductAreaController : Controller
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private ButtonView _buttonPrefab;
    [SerializeField] private GameObject _productWindowObj;
    [SerializeField] private Transform _productAreaParent;
    
    private List<ButtonView> _buttons = new List<ButtonView>();
    
    public override void Init()
    {
        _closeButton.onClick.AddListener(() =>
        {
            _productWindowObj.SetActive(false);
            CloseWindow();
        });
    }

    public override void AddModel(Model model)
    {
        base.AddModel(model);
        
        ButtonView buttonView = GetButtonView();
        buttonView.button.onClick.AddListener(model.OpenWindow);
        buttonView.UpdateView(model);
    }

    public override void Dispose()
    {
        foreach (var model in _models)
        {
            _closeButton.onClick.RemoveListener(model.CloseWindow);
        }
        
        base.Dispose();
    }

    private ButtonView GetButtonView()
    {
        ButtonView buttonView = Instantiate(_buttonPrefab);
        buttonView.transform.SetParent(_productAreaParent);
        buttonView.transform.localScale = Vector3.one;
        _buttons.Add(buttonView);

        return buttonView;
    }

    private void CloseWindow()
    {
        _currentModel.CloseWindow();
    }
    
    private void SelectModel(Model model)
    {
        _currentModel = model;
    }
    
    
}
