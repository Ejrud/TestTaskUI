using TMPro;
using UnityEngine;

public class DonateDiscountView : View
{
    [SerializeField] private GameObject _percentageBg;
    [SerializeField] private TMP_Text _percentageValue;
    
    public override void UpdateView(Model model)
    {
        _icon.sprite = model.Data.Icon;
        _header.text = model.Data.Header;
        _description.text = model.Data.Description;
        
        _price.text = "$" + (model.Data.Price * (1 - (model.Data.DiscountPercentage * 0.01f))) + "\n <s>" + model.Data.Price.ToString() + "</s>"; // TODO сюда вставлять старую цену с новой
        
        _percentageValue.text = model.Data.DiscountPercentage.ToString();
        _percentageBg.SetActive(true);
    }

    public override void ClearView()
    {
        base.ClearView();
        
        _percentageValue.text = "";
        _percentageBg.SetActive(false);
    }
}
