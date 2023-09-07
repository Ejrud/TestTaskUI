using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ButtonInputController : Controller
{
    // TODO добавить еще один view для отображения кнопок в зависимости от количества моделей
    [SerializeField] private List<ButtonLink> _buttonLinks = new List<ButtonLink>();

    public ButtonInputController(List<Model> models) : base(models) { }

    public override void Init()
    {
        _model[0].OpenWindow();
        
        // foreach (var i in _buttonLinks)
        // {
        //     i.button.onClick.AddListener(i.Model.OpenWindow);
        // }
    }
}