using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    private PlayerRotation playerRotation;
    [SerializeField] private VerticalRotation verticalRotation;

    [SerializeField] private float sencetivity = 6f;

    private void Awake()
    {
        playerRotation = GetComponent<PlayerRotation>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        verticalRotation.Rotate(verticalInput, sencetivity);
        playerRotation.Rotate(horizontalInput, sencetivity);
    }
}
