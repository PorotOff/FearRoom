using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed = 2f;

    private MoveComponent moveComponent;

    private void Awake()
    {
        moveComponent = new PlayerMovement(gameObject, );
    }

    private void Update()
    {
        
    }
}