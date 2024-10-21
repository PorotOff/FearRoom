using UnityEngine;
using UnityEngine.Events;

public class KeyboardInputManager : MonoBehaviour
{
    public static UnityEvent OnPlayerPickingObject = new UnityEvent();

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) OnPlayerPickingObject?.Invoke();
    }
}