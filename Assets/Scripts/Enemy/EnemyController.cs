using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterBase
{
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private WeaponBase equippedWeapon = null;

    private MoverBase enemyMover;
    private Transform player;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
        enemyMover = new NavAgentMover(GetComponent<NavMeshAgent>());
    }

    private void Update()
    {
        var distanceToTarget = Vector3.Distance(player.position, transform.position);
        if (distanceToTarget < chaseRange)
            enemyMover.Move(player.position);
        else
            enemyMover.Move(initialPosition);

        if (target != null)
        {
            if (!enemyMover.IsMoving && IsTargetInAttackRange())
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        GetNearestCharacter(CharacterType.Player);
    }

    private bool IsTargetInAttackRange()
    {
        return Vector3.Distance(transform.position, target.position) <= equippedWeapon.AttackRange;
    }
}
