using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    StateManager stateManager;

    public float speed = 5.0f;
    private Rigidbody characterRigidbody;

    public void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bool isKeyPressed = InputKey(); // Fix: Change InputKey() to a method that returns a bool

        EState isMoving = isKeyPressed ? EState.Walk : EState.Idle; // Fix: Corrected the logic for state transition

        stateManager.TransitionTo(isMoving);
    }

    public bool InputKey() // Fix: Change return type from void to bool
    {
        

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = characterRigidbody.linearVelocity.y;

        Vector3 velocity = new Vector3(inputX, -4.22f, inputZ);
        velocity *= speed;
        velocity.y = fallSpeed;
        characterRigidbody.linearVelocity = velocity;

        // Return true if any input is detected
        return inputX != 0 || inputZ != 0;
    }
}
