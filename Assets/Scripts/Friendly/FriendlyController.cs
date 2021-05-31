using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyController : MonoBehaviour
{
    [SerializeField] private CharacterSettings characterData = null;
    [SerializeField] private float chaseRange = 10f;

    private MoverBase enemyMover;
    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        enemyMover = new NavAgentMover(GetComponent<NavMeshAgent>());
    }

    private void Update()
    {
        //Create StateMachine for chasing/following/captive states??
        //Create a newPosition manager which returns the correct position based on friendly positions.
        //When attacking an enemy, if possible the position should be different then the position of the other friendlies.
        //Need to dynamically calculate following positions. Maybe position calculator?
    }
}
