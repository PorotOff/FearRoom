using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float currentHorizontalRotation = 0f;

    public void Rotate(float horizontalInput, float sencetivity)
    {
        currentHorizontalRotation += horizontalInput * sencetivity;

        transform.localRotation = Quaternion.Euler(0f, currentHorizontalRotation, 0f);
    }
}
