using System.Collections.Generic;
using UnityEngine;

public class DetectableObjectDetector : RaycastObjectDetector
{
    protected Dictionary<Collider, IDetectable> cachedDetectedObjects = new Dictionary<Collider, IDetectable>();

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