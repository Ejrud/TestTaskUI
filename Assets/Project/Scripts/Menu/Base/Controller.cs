using System.Collections.Generic;

public abstract class Controller
{
    protected List<Model> _model;

    public Controller(List<Model> model)
    {
        _model = model;
    }

    public abstract void Init();
}
