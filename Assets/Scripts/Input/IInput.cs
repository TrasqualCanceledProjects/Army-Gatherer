using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    void GetInput();
    float Horizontal { get; }
    float Vertical { get; }
    Vector3 MovementVector { get; }
}
