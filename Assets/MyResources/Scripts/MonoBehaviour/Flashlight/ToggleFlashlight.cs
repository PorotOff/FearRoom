using UnityEngine;

public class ToggleFlashlight : MonoBehaviour
{
    private Toggleable toggleableLight;

    private void Awake()
    {
        toggleableLight = GetComponentInChildren<Toggleable>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            toggleableLight.Toggle();
        }
    }
}