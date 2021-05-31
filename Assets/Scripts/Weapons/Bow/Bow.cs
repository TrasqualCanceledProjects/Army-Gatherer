using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponBase
{
    public override void WeaponAttack()
    {
        Debug.Log("attacked with" + name + "" + transform.parent.name);
    }
}
