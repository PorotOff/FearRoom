using UnityEngine;

public class RaycastObjectDetector : MonoBehaviour, IDetectedObject
{
    private Camera playerCamera;
    [SerializeField] private float detectionRayLenght = 50f;

    private Ray cameraRay { get; set; }
    private RaycastHit hit;

    private void Awake()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        Detect();

        DrawDebugRay();
    }

    public void Detect()
    {
        cameraRay = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        if (Physics.Raycast(cameraRay, out hit, detectionRayLenght, ~0, QueryTriggerInteraction.Collide))
        {
            var detectedObject = hit.collider.GetComponent<IDetectable>();
            if (detectedObject != null)
            {
                detectedObject.OnDetected();
            }
        }
    }

    private void DrawDebugRay()
    {
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * detectionRayLenght, Color.red);
    }
}