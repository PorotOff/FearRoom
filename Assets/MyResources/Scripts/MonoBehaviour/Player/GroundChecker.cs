using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded { get; set; }

    private void Awake()
    {
        IsGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}
