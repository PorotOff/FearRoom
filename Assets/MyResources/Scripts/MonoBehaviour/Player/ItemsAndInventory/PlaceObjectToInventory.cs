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
        PushEToInteract.OnPlayerInteractedWith.AddListener(PlaceToInventory);
    }
    private void OnDisable()
    {
        PushEToInteract.OnPlayerInteractedWith.RemoveListener(PlaceToInventory);
    }

    private void PlaceToInventory(GameObject interactedObject)
    {
        PickableObject pickedObject = interactedObject.GetComponent<PickableObject>();

        if (pickedObject != null)
        {
            inventory.AddItem(pickedObject.pickableItemParameters);

            pickedObject.DestroyOnPickedUp();
        }
    }
}