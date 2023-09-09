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
    [SerializeField] protected ItemFrame[] _itemFrames;
    
    public override void UpdateView(Model model)
    {
        _header.text = model.Data.Header;
        _description.text = model.Data.Description;
        _price.text = model.Data.Price.ToString();
        _donateName.text = model.Data.IconName;
        
        HideItems();

        for (int i = 0; i < model.Data.Items.Count; i++)
        {
            _itemFrames[i].UpdateView(model.Data.Items[i]);
            _itemFrames[i].gameObject.SetActive(true);
        }
    }

    public override void ClearView()
    {
        _icon.sprite = null;
        _header.text = "";
        _description.text = "";
        _price.text = "";
    }

    private void HideItems()
    {
        foreach (var itemFrame in _itemFrames)
        {
            itemFrame.gameObject.SetActive(false);
        }
    }
}
