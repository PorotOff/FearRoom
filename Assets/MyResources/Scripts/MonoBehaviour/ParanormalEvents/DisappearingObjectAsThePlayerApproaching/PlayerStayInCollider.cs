using UnityEngine;
using UnityEngine.Events;

public class PlayerStayInCollider : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlayerInCollider = new UnityEvent<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        
    }
}