using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectDetector : MonoBehaviour, IObjectDetector
{
    protected CameraRayProvider rayProvider;
    protected float detectionRayLenght;

    public ObjectDetector(CameraRayProvider rayProvider, float detectionRayLenght)
    {
        this.rayProvider = rayProvider;
        this.detectionRayLenght = detectionRayLenght;
    }

    public void Detect()
    {
        Ray cameraRay = rayProvider.GetRay();

        if (Physics.Raycast(cameraRay, out RaycastHit hit, detectionRayLenght, ~0, QueryTriggerInteraction.Collide))
        {
            ProcessHit(hit.collider);
        }
    }

    protected abstract void ProcessHit(Collider hittedCollider);
}