using UnityEngine;

public class JoystickInput : MonoBehaviour,IInput
{
    Joystick joystick;

    public float Horizontal { get; private set; }

    public float Vertical { get; private set; }

    public Vector3 MovementVector { get; private set; }

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    public void GetInput()
    {
        Horizontal = joystick.Horizontal;
        Vertical = joystick.Vertical;
        MovementVector = new Vector3(Horizontal, 0f, Vertical);
    }
}
