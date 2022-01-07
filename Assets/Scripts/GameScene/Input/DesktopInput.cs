using UnityEngine;

public class DesktopInput : IInput
{
    public bool StartClick => Input.GetMouseButtonDown(0);
    public bool Clicking => Input.GetMouseButton(0);
    public bool EndClick => Input.GetMouseButtonUp(0);
    public Vector3 Position => Input.mousePosition;
}   