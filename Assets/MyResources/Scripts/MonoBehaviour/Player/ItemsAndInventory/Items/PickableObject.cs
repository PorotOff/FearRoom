using UnityEngine;

public class PickableObject : MonoBehaviour, IPickableObject
{
    public PickableItem pickableItemParameters;

    public void DestroyOnPickedUp()
    {
        Destroy(gameObject);
    }
}