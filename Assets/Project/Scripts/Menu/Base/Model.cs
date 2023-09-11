using System;
using UnityEngine;

[Serializable]
public abstract class Model
{
    public Action<Model> OnSelected;
    public Action<Model> OnRejected;
    public ProductData Data => _data;

    [SerializeField] protected ProductData _data;
    protected View _view;

    public Model(ProductData data, View view)
    {
        _data = data;
        _view = view;
    }

    public abstract void OpenWindow();
    public abstract void CloseWindow();
}
