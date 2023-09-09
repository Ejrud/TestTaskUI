using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductView : View
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _header;
    [SerializeField] protected TMP_Text _description;
    [SerializeField] protected TMP_Text _price;
    [SerializeField] protected TMP_Text _donateName;
    
    public override void UpdateView(Model model)
    {
        _header.text = model.Data.Header;
        _description.text = model.Data.Description;
        _price.text = model.Data.Price.ToString();
        _donateName.text = model.Data.IconName;
    }

    public override void ClearView()
    {
        _icon.sprite = null;
        _header.text = "";
        _description.text = "";
        _price.text = "";
    }
}
