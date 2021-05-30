using UnityEngine;

public class TransformMover : MoverBase
{
    private readonly Transform transformToMove;
    private readonly IInput input;
    private readonly CharacterSettings characterData;
    private Quaternion lastRotation;

    public TransformMover(Transform transformToMove, IInput input, CharacterSettings characterData)
    {
        this.input = input;
        this.transformToMove = transformToMove;
        this.characterData = characterData;
    }

    public override void Move()
    {
        Rotate();
        transformToMove.position += transformToMove.forward * input.MovementVector.magnitude * Time.deltaTime * characterData.MoveSpeed;
    }

    public void Rotate()
    {
        if (input.MovementVector.magnitude > 0)
        {
            transformToMove.rotation = Quaternion.LookRotation(input.MovementVector.normalized * Time.deltaTime * characterData.TurnSpeed);
            lastRotation = transformToMove.rotation;
        }
        else
        {
            transformToMove.rotation = lastRotation;
        }
    }
}
