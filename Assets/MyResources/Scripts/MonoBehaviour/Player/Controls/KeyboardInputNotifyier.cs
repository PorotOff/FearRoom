using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInputNotifyier : MonoBehaviour
{
    public static UnityEvent OnEPressing = new UnityEvent();

    public static event Action OnSpacePressed;
    public static event Action<float, float> OnWASDPressing;
    public static event Action OnShiftPressing;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) OnEPressing?.Invoke();

        if (Input.GetKeyDown(KeyCode.Space)) OnSpacePressed?.Invoke();

        if (Input.GetKey(KeyCode.LeftShift)) OnShiftPressing?.Invoke();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        OnWASDPressing?.Invoke(horizontalInput, verticalInput);
    }
}