using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : AICharacter
{
    private Quaternion initialRotation;

    public override void Awake()
    {
        base.Awake();
        navAgent = GetComponent<NavMeshAgent>();
        enemyMover = new NavAgentMover(navAgent);
        initialRotation = transform.rotation;
    }

    public override void Update()
    {
        base.Update();
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * characterData.TurnSpeed);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        GetNearestCharacter(CharacterType.Player);
    }
}
