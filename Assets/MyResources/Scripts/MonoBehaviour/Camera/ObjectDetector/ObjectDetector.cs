using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    public static UnityEvent<GameObject> OnAnyObjectDetected = new UnityEvent<GameObject>();

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

            OnAnyObjectDetected?.Invoke(hittedCollider.gameObject);

            Debug.Log($"Object detected: {hittedCollider.gameObject.name}");
        }

        debugRayDrawer.DebugDrawRay(cameraRay, detetctionRayLenght, Color.green);
    }
}