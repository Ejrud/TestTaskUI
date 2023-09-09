using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract void UpdateView(Model model);

    public abstract void ClearView();

}
