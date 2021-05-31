using UnityEngine;

[CreateAssetMenu]
public class CharacterSettings : ScriptableObject
{
    [Header("MovementParameters")]
    [SerializeField] private float turnSpeed = 25f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private CharacterType characterType = CharacterType.Player;

    public float TurnSpeed { get { return turnSpeed; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public CharacterType CharacterType { get { return characterType; } }
}
