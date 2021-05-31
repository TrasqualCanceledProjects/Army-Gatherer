using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    CharacterBase character;

    private void Start()
    {
        character = GetComponentInParent<CharacterBase>();
        character.OnAttack += WeaponAttack;
    }

    public override void WeaponAttack()
    {
        Debug.Log("attacked with sword");
    }
}
