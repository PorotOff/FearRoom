using UnityEngine;

public class ObjectDetectionSystem : MonoBehaviour
{
    [SerializeField] private float detectionRayLenght = 10f;

    private IObjectDetector objectDetector;
    private CameraRayProvider rayProvider;
    private DebugRayDrawer debugRayDrawer;

    private void Awake()
    {
        Camera playerCamera = Camera.main;
        rayProvider = new CameraRayProvider(playerCamera);
        objectDetector = new RaycastObjectDetector(rayProvider, detectionRayLenght);
        debugRayDrawer = new DebugRayDrawer();
    }

    private void Update()
    {
        objectDetector.Detect();
        debugRayDrawer.DebugDrawRay(rayProvider.GetRay(), detectionRayLenght, Color.green);
    }
}