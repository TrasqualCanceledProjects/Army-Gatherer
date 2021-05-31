using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected CharacterSettings characterData = null;
    [SerializeField] protected WeaponBase equippedWeapon = null;

    public event Action OnAttack;

    private Transform target;

    protected void CharactersOfTypeInRange(CharacterType characterTypeToCheck)
    {
        foreach (var collider in Utilities.InRangeCheck(transform.position, equippedWeapon.AttackRange))
        {

        }
    }

    protected bool IsAnyEnemyInRange()
    {
        return (Utilities.InRangeCheck(transform.position, equippedWeapon.AttackRange).Length != 0);
    }

    protected void Attack(float range)
    {
        OnAttack?.Invoke();
    }
}
