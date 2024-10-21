using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    private CameraRayProvider rayProvider;
    [SerializeField] private float detetctionRayLenght;
    private DebugRayDrawer debugRayDrawer;

    protected Dictionary<Collider, IDetectable> cachedDetectedObjects = new Dictionary<Collider, IDetectable>();

    private void Awake()
    {
        Camera playerCamera = Camera.main;
        rayProvider = new CameraRayProvider(playerCamera);
        debugRayDrawer = new DebugRayDrawer();
    }

    private void Update()
    {
        Detect();
    }

    private void Detect()
    {
        Ray cameraRay = rayProvider.GetRay();

        if (Physics.Raycast(cameraRay, out RaycastHit hit, detetctionRayLenght, ~0, QueryTriggerInteraction.Collide))
        {
            Collider hittedCollider = hit.collider;

            if (cachedDetectedObjects.TryGetValue(hittedCollider, out IDetectable detectedDetectableObject))
            {
                detectedDetectableObject.OnDetected(hittedCollider.gameObject);
            }
            else
            {
                detectedDetectableObject = hittedCollider.GetComponent<IDetectable>();

                if (detectedDetectableObject != null)
                {
                    detectedDetectableObject.OnDetected(hittedCollider.gameObject);
                    cachedDetectedObjects[hittedCollider] = detectedDetectableObject;
                }
            }
        }

        debugRayDrawer.DebugDrawRay(cameraRay, detetctionRayLenght, Color.green);
    }
}