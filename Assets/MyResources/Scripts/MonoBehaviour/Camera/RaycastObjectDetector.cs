using UnityEngine;

public class RaycastObjectDetector : MonoBehaviour, IObjectDetector
{
    private CameraRayProvider rayProvider;
    private float detectionRayLenght;

    public RaycastObjectDetector(CameraRayProvider rayProvider, float detectionRayLenght)
    {
        this.rayProvider = rayProvider;
        this.detectionRayLenght = detectionRayLenght;
    }

    public void Detect()
    {
        Ray cameraRay = rayProvider.GetRay();

        if (Physics.Raycast(cameraRay, out RaycastHit hit, detectionRayLenght, ~0, QueryTriggerInteraction.Collide))
        {
            IDetectable detectedObject = hit.collider.GetComponent<IDetectable>();
            
            if (detectedObject != null)
            {
                detectedObject.OnDetected();
            }
        }
    }
}