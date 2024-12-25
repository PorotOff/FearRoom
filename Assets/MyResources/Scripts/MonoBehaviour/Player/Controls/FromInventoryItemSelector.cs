using UnityEngine;
using UnityEngine.Events;

public class FromInventoryItemSelector : MonoBehaviour
{
    public static UnityEvent<int> OnItemSelected = new UnityEvent<int>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) OnItemSelected?.Invoke(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) OnItemSelected?.Invoke(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) OnItemSelected?.Invoke(2);
    }
}