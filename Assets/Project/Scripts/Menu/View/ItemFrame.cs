using TMPro;
using UnityEngine;

public sealed class ItemFrame : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemCount;
    
    public void UpdateView(ItemStack itemStack)
    {
        _itemName.text = itemStack.name;
        _itemCount.text = itemStack.count.ToString();
    }

}
