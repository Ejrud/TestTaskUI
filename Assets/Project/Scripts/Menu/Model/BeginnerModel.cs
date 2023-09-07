using System;

[Serializable]
public class BeginnerModel : Model
{
    public BeginnerModel(View view, ModelData data) : base(data, view)
    {
    }

    public override void OpenWindow()
    {
        throw new System.NotImplementedException();
    }
}
