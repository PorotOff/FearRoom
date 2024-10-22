using UnityEngine;

public class DetectObject : MonoBehaviour
{
    private void OnEnable()
    {
        ObjectDetector.OnAnyObjectDetected.AddListener(Detect);
    }
    private void OnDisable()
    {
        ObjectDetector.OnAnyObjectDetected.RemoveListener(Detect);
    }

    private void Detect(GameObject detectedObjectByRay)
    {
        IDetectable detectedObject = detectedObjectByRay.GetComponent<IDetectable>();

        if (detectedObject != null)
        {
            detectedObject.OnDetected();
        }
    }
}