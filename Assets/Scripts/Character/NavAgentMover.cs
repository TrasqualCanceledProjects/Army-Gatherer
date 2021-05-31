using UnityEngine;
using UnityEngine.AI;

public class NavAgentMover : MoverBase
{
    private readonly NavMeshAgent navAgentToMove;

    public NavAgentMover(NavMeshAgent navAgentToMove)
    {
        this.navAgentToMove = navAgentToMove;
    }

    public override bool IsMoving {get { return navAgentToMove.velocity.magnitude > 0; } }

    public override void Move(Vector3 target)
    {
        navAgentToMove.SetDestination(target);
    }
}
