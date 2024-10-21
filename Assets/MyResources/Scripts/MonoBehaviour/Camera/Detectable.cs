using UnityEngine;

public abstract class Detectable : MonoBehaviour
{
    public abstract void OnDetected();
    public abstract void OnDetected(GameObject detectedObject);
}