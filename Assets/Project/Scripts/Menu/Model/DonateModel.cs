using System;

[Serializable]
public class DonateModel : Model
{
    public DonateModel(View view, ModelData data) : base(data, view)
    {
    }

    public override void OpenWindow()
    {
        _view.gameObject.SetActive(true);
        _view.UpdateView(this);
    }
}
