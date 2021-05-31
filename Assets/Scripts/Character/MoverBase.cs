using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBase
{
    public virtual bool IsMoving { get; set; }
    public virtual void Move() { }
    public virtual void Move(Vector3 target) { }
}
