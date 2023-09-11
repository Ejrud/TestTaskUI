using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductView : View
{
    // В идеале сделать Init метод и передавать туда _spriteLibrary и каждый view сделать в виде префаба,
    // но заморачиваться над этим не вижу смысла
    [SerializeField] protected SpriteLibrary _spriteLibrary;
    
    [Header("UI")]
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _header;
    [SerializeField] protected TMP_Text _description;
    [SerializeField] protected TMP_Text _price;
    [SerializeField] protected TMP_Text _donateName;
    [SerializeField] protected ItemFrame[] _itemFrames;
    
    public override void UpdateView(Model model)
    {
        _icon.sprite = _spriteLibrary.GetSpriteByName(model.Data.iconName);
        _header.text = model.Data.header;
        _description.text = model.Data.description;
        _price.text = "$" + model.Data.price;
        _donateName.text = model.Data.iconName;
        
        HideItems();
        
        for (int i = 0; i < model.Data.items.Count; i++)
        {
            Sprite itemSprite = _spriteLibrary.GetSpriteByName(model.Data.items[i].item.iconName);
            _itemFrames[i].UpdateView(model.Data.items[i], itemSprite);
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
