using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    public float AttackRange { get { return weaponData.AttackRange; } }
    public float Damage { get { return weaponData.Damage; } }

    CharacterBase character;

    private void Start()
    {
        character = GetComponentInParent<CharacterBase>();
        if(character != null)
        character.OnAttack += WeaponAttack;
    }

    public abstract void WeaponAttack();
}
