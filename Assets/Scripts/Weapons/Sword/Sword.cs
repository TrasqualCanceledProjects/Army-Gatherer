using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    public override void WeaponAttack()
    {
        Debug.Log("attacked with sword" + transform.parent.name);
    }
}
