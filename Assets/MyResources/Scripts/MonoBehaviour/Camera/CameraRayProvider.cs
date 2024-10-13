using UnityEngine;

public class CameraRayProvider : MonoBehaviour
{
    private Camera playerCamera;

    public CameraRayProvider(Camera camera)
    {
        playerCamera = camera;
    }

    public Ray GetRay()
    {
        Vector3 startRayPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

        return playerCamera.ScreenPointToRay(startRayPosition);
    }
}