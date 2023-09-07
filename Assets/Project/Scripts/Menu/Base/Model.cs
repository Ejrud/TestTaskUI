using System;
using UnityEngine;

[Serializable]
public abstract class Model
{
    public ModelData Data => _data;
    
    [SerializeField] protected ModelData _data;
    protected View _view;

    public Model(ModelData data, View view)
    {
        _data = data;
        _view = view;
    }

    public abstract void OpenWindow();
}
