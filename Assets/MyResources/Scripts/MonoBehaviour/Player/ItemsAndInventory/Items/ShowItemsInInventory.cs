using UnityEngine;
using UnityEngine.UI;

public class ShowItemsInInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private RectTransform inventoryUI;
    [SerializeField] private Vector2 iconSize;

    private void Awake()
    {
        inventoryUI = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        inventory.OnItemPlacedInInventory.AddListener(UpdateInventory);
    }
    private void OnDisable()
    {
        inventory.OnItemPlacedInInventory.RemoveListener(UpdateInventory);
    }

    private void UpdateInventory()
    {
        if (inventoryUI.childCount > 0)
        {
            foreach (Transform item in inventoryUI)
            {
                Destroy(item.gameObject);
            }
        }

        for (int i = 0; i < inventory.InventoryItems.Count; i++)
        {
            PickableItem newItem = inventory.InventoryItems[i];

            GameObject icon = new GameObject("Icon");
            Image itemIcon = icon.AddComponent<Image>();
            itemIcon.sprite = newItem.ItemIcon;
            itemIcon.rectTransform.sizeDelta = iconSize;

            icon.transform.SetParent(inventoryUI);
        }
    }
}