using UnityEngine;

public class VerticalRotation : MonoBehaviour
{
    private float verticalCameraRotation = 0f;

    [SerializeField] private float minVerticalLookRestriction = -90f;
    [SerializeField] private float maxVerticalLookRestriction = 90f;

    public void Rotate(float verticalInput, float sencetivity)
    {
        verticalCameraRotation -= verticalInput * sencetivity;
        verticalCameraRotation = Mathf.Clamp(verticalCameraRotation, minVerticalLookRestriction, maxVerticalLookRestriction);
        
        gameObject.transform.localRotation = Quaternion.Euler(verticalCameraRotation, 0f, 0f);
    }
}