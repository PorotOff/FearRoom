using System.Collections.Generic;
using UnityEngine;

public class DetectableObjectDetector : ObjectDetector
{
    protected Dictionary<Collider, IDetectable> cachedDetectedObjects = new Dictionary<Collider, IDetectable>();

    public DetectableObjectDetector(CameraRayProvider cameraRayProvider, float detectionRayLenght)
        : base(cameraRayProvider, detectionRayLenght) { }

    protected override void ProcessHit(Collider hittedCollider)
    {
        if (cachedDetectedObjects.TryGetValue(hittedCollider, out IDetectable detectedObject))
        {
            detectedObject.OnDetected();
        }
        else
        {
            detectedObject = hittedCollider.GetComponent<IDetectable>();

            if (detectedObject != null)
            {
                detectedObject.OnDetected();
                cachedDetectedObjects[hittedCollider] = detectedObject;
            }
        }
    }
}