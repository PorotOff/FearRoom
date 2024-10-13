using UnityEngine;

public class SelectItemToHand : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private bool isImmediatlyPlacePickedUpItemToHand = true;

    private Transform playerHandTransform;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        playerHandTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        inventory.OnItemPlacedInInventory.AddListener(ImmediatlySelect);
        KeyboardInputManager.OnItemSelected.AddListener(Select);
    }
    private void OnDisable()
    {
        inventory.OnItemPlacedInInventory.RemoveListener(ImmediatlySelect);
        KeyboardInputManager.OnItemSelected.RemoveListener(Select);
    }

    private void Select(int index)
    {
        if (playerHandTransform.childCount > 0)
        {
            foreach (Transform item in playerHandTransform)
            {
                Destroy(item.gameObject);
            }
        }

        PickableItem newItem = inventory.InventoryItems[index];

        GameObject newHandObject = Instantiate(newItem.ItemPrefab, playerHandTransform);
        
        ChangeObjectLayer(newHandObject, 6);
    }
    private void ImmediatlySelect()
    {
        if (isImmediatlyPlacePickedUpItemToHand)
        {
            int lastPlacedItemNumber = inventory.InventoryItems.Count - 1;

            Select(lastPlacedItemNumber);
        }
    }
    
    private void ChangeObjectLayer(GameObject currentObject, int layer)
    {
        currentObject.layer = layer;

        foreach (Transform obj in currentObject.transform)
        {
            ChangeObjectLayer(obj.gameObject, layer);
        }
    }
}