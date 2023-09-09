using UnityEngine;

public abstract class View : MonoBehaviour
{
    [SerializeField] protected GameObject _viewObject;
    
    public abstract void UpdateView(Model model);

    public abstract void ClearView();

    public virtual void SetActiveView(bool active)
    {
        _viewObject.SetActive(active);
    }

}
