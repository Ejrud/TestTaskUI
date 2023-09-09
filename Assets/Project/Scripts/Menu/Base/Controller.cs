using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected List<Model> _models = new List<Model>();
    
    public abstract void AddModel(Model model);
}
