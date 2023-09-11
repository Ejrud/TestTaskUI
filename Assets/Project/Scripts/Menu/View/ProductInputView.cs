using UnityEngine;

public sealed class ProductInputView : MonoBehaviour
{
    public ItemInputFrame[] ItemInputFrames => _itemInputFrames;
    [SerializeField] private ItemInputFrame[] _itemInputFrames;
    private int _frameIndex;
    
    public void Init(ItemType[] itemTypes)
    {
        ClearItems();
        foreach (var inputFrame in _itemInputFrames)
        {
            inputFrame.Init(itemTypes);
        }
    }

    public void OpenItemInputFrame()
    {
        _itemInputFrames[_frameIndex].SetActive(true);
        _frameIndex++;
    }

    public void ClearItems()
    {
        _frameIndex = 0;
        foreach (var inputFrame in _itemInputFrames)
        {
            inputFrame.SetActive(false);
        }
    }

    public bool IsItemsEmpty()
    {
        bool isEmpty = true;
        foreach (var inputFrame in _itemInputFrames)
        {
            if (!inputFrame.isCreated)
                continue;

            isEmpty = false;
            
            if (inputFrame.IsEmpty())
                return true;
        }

        return isEmpty;
    }

    public bool IsExceededLimit()
    {
        foreach (var inputFrame in _itemInputFrames)
        {
            if (!inputFrame.isCreated)
                return false;
        }

        return true;
    }
}
