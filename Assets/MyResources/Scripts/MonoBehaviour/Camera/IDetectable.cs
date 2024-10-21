using UnityEngine;

public interface IDetectable
{
    void OnDetected();
    void OnDetected(GameObject detectedObject);
}