using UnityEngine;

public class PlayerController : CharacterBase
{
    [SerializeField] private CharacterSettings characterData = null;
    [SerializeField] private WeaponBase equippedWeapon = null;

    private IInput characterInput;
    private MoverBase mover;

    public void Awake()
    {
        charactersType = characterData.CharacterType;
        characterInput = GetComponent<IInput>();
        mover = new TransformMover(transform, characterInput, characterData);
    }

    public void Update()
    {
        characterInput.GetInput();
        mover.Move();
        if(target != null)
        {
            if (!mover.IsMoving && IsTargetInAttackRange())
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        GetNearestCharacter(CharacterType.Enemy);
    }

    private bool IsTargetInAttackRange()
    {
        return Vector3.Distance(transform.position, target.position) <= equippedWeapon.AttackRange;
    }
}
