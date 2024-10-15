using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) playerMovement.Jump();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        playerMovement.Move(horizontalInput, verticalInput, isShiftPressed);
    }
}