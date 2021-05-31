using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    public float AttackRange { get { return weaponData.AttackRange; } }
    public float Damage { get { return weaponData.Damage; } }

    public abstract void WeaponAttack();
}
