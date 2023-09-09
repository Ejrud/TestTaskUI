using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductAreaController : Controller
{
    // ProductAreaController отвечает за отображение продукта по нажатию кнопок
    [SerializeField] private ButtonView _buttonPrefab;
    
    private Button _closeButton;
    private GameObject _productWindowObj;
    private Transform _productAreaParent;
    private List<ButtonView> _buttons = new List<ButtonView>();
    
    public void Init(GameObject productArea, Transform productAreaParent, Button closeButton)
    {
        _productAreaParent = productAreaParent;
        _productWindowObj = productArea;
        _closeButton = closeButton;
        
        _closeButton.onClick.AddListener(() => 
            { _productWindowObj.SetActive(false); });
    }

    public override void AddModel(Model model)
    {
        ButtonView buttonView = GetButtonView();
        buttonView.button.onClick.AddListener(model.OpenWindow);
        buttonView.UpdateView(model);
        
        _closeButton.onClick.AddListener(model.CloseWindow);
        _models.Add(model);
    }

    private ButtonView GetButtonView()
    {
        ButtonView buttonView = Instantiate(_buttonPrefab);
        buttonView.transform.SetParent(_productAreaParent);
        buttonView.transform.localScale = Vector3.one;
        _buttons.Add(buttonView);

        return buttonView;
    }
}
