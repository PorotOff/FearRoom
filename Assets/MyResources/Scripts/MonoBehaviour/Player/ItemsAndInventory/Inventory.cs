using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnItemPlacedInInventory = new UnityEvent();

    [HideInInspector] public List<PickableItem> InventoryItems = new List<PickableItem>();
    [SerializeField] private int maxCapacity = 10;

    public void AddItem(PickableItem item)
    {
        if (InventoryItems.Count < maxCapacity)
        {
            InventoryItems.Add(item);

            OnItemPlacedInInventory?.Invoke();
        }
        else
        {
            throw new UnityException("Inventory has no space");
        }
    }

    public PickableItem GetItem(int index)
    {
        if (index >= 0 && index < InventoryItems.Count)
        {
            return InventoryItems[index];
        }

        return null;
    }
}