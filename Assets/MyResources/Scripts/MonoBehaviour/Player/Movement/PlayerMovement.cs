using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MoveComponent
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 5f;
    
    private GroundChecker groundChecker;

    private Rigidbody playerRigidbody;
    private Transform playerTransform;

    public PlayerMovement(GameObject currentObject, float horizontalInput, float verticalInput, float speed)
    {
        playerRigidbody = currentObject.GetComponent<Rigidbody>();
        playerTransform = currentObject.GetComponent<Transform>();

        this.horizontalInput = horizontalInput;
        this.verticalInput = verticalInput;
        this.speed = speed;
    }

    public override void Move()
    {
        Vector3 currentVelocity = playerRigidbody.linearVelocity;
        Vector3 newVelocity = GetDirection() * GetSpeed();
        newVelocity.y = currentVelocity.y;

        if (!groundChecker.IsGrounded)
        {
            newVelocity = currentVelocity;
        }

        playerRigidbody.linearVelocity = newVelocity;
    }

    protected override Vector3 GetDirection()
    {
        Vector3 newMovementDirection = playerTransform.forward * verticalInput + playerTransform.right * horizontalInput;
        newMovementDirection.Normalize();

        return newMovementDirection;
    }

    protected override float GetSpeed()
    {
        return speed;
    }
}
