using UnityEngine;

public abstract class RaycastObjectDetector : MonoBehaviour, IObjectDetector
{
    protected CameraRayProvider rayProvider;
    [SerializeField] protected float detectionRayLenght;
    [SerializeField] private Color rayColor;

    private DebugRayDrawer debugRayDrawer;

    protected virtual void Awake()
    {
        Camera playerCamera = Camera.main;
        rayProvider = new CameraRayProvider(playerCamera);
        debugRayDrawer = new DebugRayDrawer();
    }

    private void Update()
    {
        Detect();
    }

    public void Detect()
    {
        Ray cameraRay = rayProvider.GetRay();

        if (Physics.Raycast(cameraRay, out RaycastHit hit, detectionRayLenght, ~0, QueryTriggerInteraction.Collide))
        {
            ProcessHit(hit.collider);
        }

        debugRayDrawer.DebugDrawRay(rayProvider.GetRay(), detectionRayLenght, rayColor);
    }

    protected abstract void ProcessHit(Collider hittedCollider);
}