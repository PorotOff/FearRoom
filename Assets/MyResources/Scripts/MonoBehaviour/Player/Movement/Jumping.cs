using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 3;

    private Rigidbody playerRigidbody;
    private GroundChecker groundChecker;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void OnEnable()
    {
        KeyboardInputNotifyier.OnSpacePressed += Jump;
    }
    private void OnDisable()
    {
        KeyboardInputNotifyier.OnSpacePressed -= Jump;
    }

    private void Jump()
    {
        if (groundChecker.IsGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}