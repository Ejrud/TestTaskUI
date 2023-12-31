﻿using UnityEngine;
using TMPro;

public class ProductDiscountView : ProductView
{
    [SerializeField] private GameObject _percentageBg;
    [SerializeField] private TMP_Text _percentageValue;
    [SerializeField] private string _oldPriceHex;
    
    public override void UpdateView(Model model)
    {
        base.UpdateView(model);

        string oldPrice = FormatPrice(model.Data.price);
        string discountPrice = FormatPrice(model.Data.price * (1 - model.Data.discountPercentage * 0.01f));
        
        _price.text = discountPrice + $"\n <color={_oldPriceHex}><s>" + oldPrice + "</s></color>";

        _percentageValue.text = "-" + model.Data.discountPercentage + "%";
        _percentageBg.SetActive(true);
    }
    
    public override void ClearView()
    {
        base.ClearView();

        _percentageValue.text = "";
        _percentageBg.SetActive(false);
    }

    private string FormatPrice(float rawPrice)
    {
        return "$" + string.Format("{0:f}", rawPrice);
    }
}
