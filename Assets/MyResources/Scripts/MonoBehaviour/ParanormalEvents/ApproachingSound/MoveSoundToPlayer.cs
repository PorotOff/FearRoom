using UnityEngine;

public class MoveSoundToPlayer : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] float movementSpeed = 0.05f;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, movementSpeed);
    }
}