using UnityEngine;

[CreateAssetMenu(fileName = "PickableItem", menuName = "Inventory/PickableItem", order = 1)]
public class PickableItem : ScriptableObject
{
    public string ItemName;
    public Sprite ItemIcon;
    public GameObject ItemPrefab;
}