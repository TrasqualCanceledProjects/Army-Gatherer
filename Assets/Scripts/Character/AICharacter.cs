using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : CharacterBase
{

    [SerializeField] private float maxDistanceToTravel = 40f;

    public event Action OnProvoked;

    protected Vector3 initialPosition;
    protected MoverBase enemyMover;
    protected NavMeshAgent navAgent;

    public override void Awake()
    {
        base.Awake();
        navAgent = GetComponent<NavMeshAgent>();
        enemyMover = new NavAgentMover(navAgent);
    }

    private void Start()
    {
        InitializeNavMesh();
    }

    public virtual void Update()
    {
        if (IsProvoked())
        {
            EngageTarget();
        }
        else
        {
            ReturnToPosition(initialPosition);
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

    private bool IsTargetInSight()
    {
        return Vector3.Distance(target.position, transform.position) <= detectionRange;
    }

    private bool IsTooFarAwayFromInitialPosition()
    {
        return Vector3.Distance(transform.position, initialPosition) > maxDistanceToTravel;
    }

    private void ReturnToPosition(Vector3 positionToReturnTo)
    {
        if (Vector3.Distance(transform.position, positionToReturnTo) < 0.1f)
        {
            return;
        }
        Debug.Log("moving back to initial pos");
        navAgent.stoppingDistance = 0;
        enemyMover.Move(positionToReturnTo);
    }

    private void EngageTarget()
    {
        if (IsTargetInAttackRange())
        {
            Attack();
        }
        else MoveToTarget();
    }

    private void MoveToTarget()
    {
        navAgent.stoppingDistance = equippedWeapon.AttackRange;
        enemyMover.Move(target.position);
    }

    private void InitializeNavMesh()
    {
        initialPosition = transform.position;
        if (equippedWeapon.AttackRange > detectionRange)
            detectionRange += equippedWeapon.AttackRange;
    }

    private bool IsProvoked()
    {
        if (target != null)
        {
            if (IsTargetInSight())
            {
                return true;
            }
            else if (!IsTargetInSight() || IsTooFarAwayFromInitialPosition())
            {
                return false;
            }
        }
        return false;
    }
}
