using UnityEngine;

public class PlaceObjectToInventory : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnEnable()
    {
        NotifyPickableObjectDetected.OnPickableObjectDetected.AddListener(PlaceToInventory);
    }
    private void OnDisable()
    {
        NotifyPickableObjectDetected.OnPickableObjectDetected.RemoveListener(PlaceToInventory);
    }

    private void PlaceToInventory(PickableItem detectedPickableItem)
    {
        if (Input.GetKey(KeyCode.E))
        {
            inventory.AddItem(detectedPickableItem);
        }
    }
}