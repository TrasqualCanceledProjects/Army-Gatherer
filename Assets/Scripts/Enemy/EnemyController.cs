using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterBase
{
    [SerializeField] private WeaponBase equippedWeapon = null;

    private MoverBase enemyMover;
    private Vector3 initialPosition;
    private NavMeshAgent navAgent;
    private float maxDistanceToTravel = 40f;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        enemyMover = new NavAgentMover(navAgent);
        equippedWeapon = GetComponentInChildren<WeaponBase>();
    }

    private void Start()
    {
        InitializeNavMesh();
    }

    private void Update()
    {
        if (target != null)
        {
            var distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget <= detectionRange)
            {
                MoveToTarget();
            }
            else if (distanceToTarget > detectionRange || DistanceFromInitialPosition() > maxDistanceToTravel)
            {
                ReturnToInitialPosition();
            }

            if (!enemyMover.IsMoving && IsTargetInAttackRange())
            {
                Attack();
            }
        }
        else
        {
            ReturnToInitialPosition();
        }
    }

    private void FixedUpdate()
    {
        GetNearestCharacter(CharacterType.Player);
    }

    private void ReturnToInitialPosition()
    {
        if (DistanceFromInitialPosition() < 0.1f)
        {
            return;
        }
        Debug.Log("moving back to initial pos");
        navAgent.stoppingDistance = 0;
        enemyMover.Move(initialPosition);
    }

    private void MoveToTarget()
    {
        navAgent.stoppingDistance = equippedWeapon.AttackRange;
        enemyMover.Move(target.position);
    }

    private bool IsTargetInAttackRange()
    {
        return Vector3.Distance(transform.position, target.position) <= equippedWeapon.AttackRange;
    }

    private void InitializeNavMesh()
    {
        initialPosition = transform.position;
        if (equippedWeapon.AttackRange > detectionRange)
            detectionRange += equippedWeapon.AttackRange;
    }

    private float DistanceFromInitialPosition()
    {
        return Vector3.Distance(transform.position, initialPosition);
    }
}
