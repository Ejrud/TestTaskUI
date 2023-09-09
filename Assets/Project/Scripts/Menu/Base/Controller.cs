using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected List<Model> _models = new List<Model>();
    protected Model _currentModel;
    public abstract void Init();

    public virtual void AddModel(Model model)
    {
        model.OnSelected += SelectModel;
        _models.Add(model);
    }

    public virtual void Dispose()
    {
        foreach (var model in _models)
        {
            model.OnSelected -= SelectModel;
        }
    }

    public virtual void SelectModel(Model selecterModel)
    {
        _currentModel = selecterModel;
    }
}
