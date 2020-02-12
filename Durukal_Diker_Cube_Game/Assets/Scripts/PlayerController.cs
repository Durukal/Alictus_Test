using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField ]
    Joystick joystick;
    Rigidbody rigidPlayer;
    float moveSpeed = 50f;
    float terminalRotationSpeed = 10f;
    Vector3 MoveVector;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidPlayer = GetComponent<Rigidbody>();
        rigidPlayer.maxAngularVelocity = terminalRotationSpeed;
    }
    
    void Update()
    {
        if (joystick.Horizontal ==0f && joystick.Vertical == 0)
        {
            rigidPlayer.velocity = Vector3.zero;
        }
                
        MoveVector = GetInput();
        if(joystick.Horizontal!=0)
        {
            Rotate();
        }

        Move();

    }
    private Vector3 GetInput()
    {
        Vector3 direction=Vector3.zero;
        direction.x = -joystick.Horizontal;
        direction.z = -joystick.Vertical;
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }
        return direction;

    }
    private void Move()
    {
        rigidPlayer.velocity=(MoveVector * moveSpeed);
    }
    private void Rotate()
    {
        rigidPlayer.gameObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(joystick.Vertical, -joystick.Horizontal) * 180 / Mathf.PI, 0);
    }
    
}
