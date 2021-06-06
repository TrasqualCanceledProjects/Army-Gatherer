using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : CharacterBase
{

    [SerializeField] private float maxDistanceToTravel = 20f;

    public event Action<Transform> OnProvoked;
    public event Action<GameObject> OnDeath;

    protected Vector3 initialPosition;
    protected MoverBase enemyMover;
    protected NavMeshAgent navAgent;

    private bool isReturning = false;
    private bool isProvokedByNearby = false;

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

    private void InitializeNavMesh()
    {
        initialPosition = transform.position;
        if (equippedWeapon.AttackRange > detectionRange)
            detectionRange += equippedWeapon.AttackRange;
    }

    public virtual void Update()
    {
        if (IsProvoked())
        {
            OnProvoked?.Invoke(target);
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
            isReturning = false;
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

    private bool IsProvoked()
    {
        if (target != null)
        {
            if (IsTooFarAwayFromInitialPosition())
            {
                isProvokedByNearby = false;
                isReturning = true;
                target = null;
                Debug.Log("I am too far away. Returning." + name);
                return false;
            }
            else if (!IsTargetInSight())
            {
                if (isProvokedByNearby)
                {
                    Debug.Log("I am alerted." + name);
                    return true;
                }
                else
                {
                    Debug.Log("Target ran away. Returning." + name);
                    return false;
                }
            }
            else if (IsTargetInSight() && !isReturning)
            {
                Debug.Log("Target near me." + name);
                return true;
            }
        }
        return false;
    }

    public void SetTarget(Transform target)
    {
        if(this.target == null && !isReturning)
        {
            this.target = target;
            isProvokedByNearby = true;
        }
    }

    public void Die()
    {
        OnDeath?.Invoke(gameObject);
    }
}
