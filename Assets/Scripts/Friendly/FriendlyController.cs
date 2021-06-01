using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyController : AICharacter
{
    public override void Awake()
    {
        base.Awake();
        navAgent = GetComponent<NavMeshAgent>();
        enemyMover = new NavAgentMover(navAgent);
    }

    private void FixedUpdate()
    {
        if (!IsCaptive())
        GetNearestCharacter(CharacterType.Enemy);
    }

    private bool IsCaptive()
    {
        return false;
    }
}
