using UnityEngine;

public class UnarmedWeapon : WeaponBase
{
    public override void WeaponAttack()
    {
        Debug.Log("attacked with" + name + "" + transform.parent.name);
    }
}
