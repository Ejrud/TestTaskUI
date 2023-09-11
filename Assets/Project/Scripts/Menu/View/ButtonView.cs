using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : View
{
    public Button button => _button;
    
    [SerializeField] private TMP_Text _buttonName;
    [SerializeField] private Button _button;
    
    public override void UpdateView(Model model)
    {
        _buttonName.text = model.Data.iconName;
    }

    public override void ClearView()
    {
        _buttonName.text = "";
    }
}