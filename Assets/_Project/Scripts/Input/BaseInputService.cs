using UnityEngine;

public abstract class BaseInputService : IInputService
{
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";

    public abstract Vector2 Axis { get; }
}