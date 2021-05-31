using System;
using System.Linq;
using UnityEngine;

public class PlayerController : CharacterBase
{
    private IInput characterInput;
    private MoverBase mover;

    public void Awake()
    {
        characterInput = GetComponent<IInput>();
        mover = new TransformMover(transform, characterInput, characterData);
    }

    public void Update()
    {
        characterInput.GetInput();
        mover.Move();
        if (!mover.IsMoving && IsAnyEnemyInRange())
        {

        }
    }

    private void FixedUpdate()
    {

    }
}
