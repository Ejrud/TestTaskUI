using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ItemFrame : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCount;
    
    public void UpdateView(ItemStack itemStack, Sprite sprite)
    {
        _itemIcon.sprite = sprite;
        _itemName.text = itemStack.name;
        _itemCount.text = itemStack.count.ToString();
    }

}
