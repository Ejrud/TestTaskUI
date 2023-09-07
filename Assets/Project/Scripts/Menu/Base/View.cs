using UnityEngine.UI;
using UnityEngine;
using TMPro;

public abstract class View : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _header;
    [SerializeField] protected TMP_Text _description;
    [SerializeField] protected TMP_Text _price;
    
    public abstract void UpdateView(Model model);

    public virtual void ClearView()
    {
        _icon.sprite = null;
        _header.text = "";
        _description.text = "";
        _price.text = "";
    }
}
