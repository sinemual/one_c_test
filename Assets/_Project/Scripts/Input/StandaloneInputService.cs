using System;
using UnityEngine;

public class StandaloneInputService : BaseInputService
{
    public override Vector2 Axis => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
}