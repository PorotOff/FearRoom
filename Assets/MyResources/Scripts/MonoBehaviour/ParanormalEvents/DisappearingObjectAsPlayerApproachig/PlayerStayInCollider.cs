using UnityEngine;

public class PlayerStayInCollider : MonoBehaviour
{
    private Transform playerTransform;
    public Transform PlayerTransform
    {
        get { return playerTransform; }
        private set { }
    }

    private Vector3 firstTouch;
    public Vector3 FirstTouch
    {
        get { return firstTouch; }
        private set { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTransform = other.transform;

            firstTouch = playerTransform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
        }
    }
}