using UnityEngine;
using UnityEngine.Events;

public class KeyboardInputManager : MonoBehaviour
{
    public static UnityEvent<int> OnItemSelected = new UnityEvent<int>();

    private PlayerMovement playerMovement;
    private PickupPickableObject pickupPickableObject;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        pickupPickableObject = GetComponent<PickupPickableObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) playerMovement.Jump();

        if (Input.GetKeyDown(KeyCode.Alpha1)) OnItemSelected?.Invoke(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) OnItemSelected?.Invoke(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) OnItemSelected?.Invoke(2);

        if (Input.GetKeyDown(KeyCode.E)) pickupPickableObject.StartPickup();
        if (Input.GetKeyUp(KeyCode.E)) pickupPickableObject.StopPickup();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        playerMovement.Move(horizontalInput, verticalInput, isShiftPressed);
    }
}
