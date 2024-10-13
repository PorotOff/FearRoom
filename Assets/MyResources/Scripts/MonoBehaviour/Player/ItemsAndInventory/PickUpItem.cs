using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PickableObject item = other.GetComponent<PickableObject>();

        if (item != null)
        {
            inventory.AddItem(item.pickableItemParameters);

            item.DestroyOnPickedUp();
        }
    }
}