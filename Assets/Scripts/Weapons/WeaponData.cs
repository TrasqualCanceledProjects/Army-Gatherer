using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    [Header("AttackParameters")]
    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float damage = 10f;

    public float AttackRange { get { return attackRange; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Damage { get { return damage; } }
}
