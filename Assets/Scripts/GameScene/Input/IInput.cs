using UnityEngine;

public interface IInput
{
    public Vector3 Position { get; }
    public bool StartClick { get; }
    public bool EndClick { get; }
    public bool Clicking { get; }
}