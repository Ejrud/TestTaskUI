using UnityEngine;

public class ControllerProvider : MonoBehaviour
{
    private Controller _controller;
    
    public void Init(Controller controllerType)
    {
        _controller = controllerType;
    }
}
