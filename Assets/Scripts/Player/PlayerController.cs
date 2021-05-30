using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterSettings characterData = null;

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
    }
}
