using UnityEngine;
using UnityEngine.Events;

public class NotifyPickableObjectDetected : MonoBehaviour, IDetectable, IPickableObject
{
    public static UnityEvent<PickableItem> OnPickableObjectDetected = new UnityEvent<PickableItem>();

    public void OnDetected(GameObject detectedObject)
    {
        PickableItem detectedPickableItem = detectedObject.GetComponent<PickableItem>();

        OnPickableObjectDetected?.Invoke(detectedPickableItem);

        DestroyOnPickedUp();
    }
    public void OnDetected()
    {
        throw new System.NotImplementedException();
    }    

    public void DestroyOnPickedUp()
    {
        // Destroy(gameObject);
    }
}