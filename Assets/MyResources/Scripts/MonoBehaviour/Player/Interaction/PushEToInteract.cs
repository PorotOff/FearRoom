using UnityEngine;
using UnityEngine.Events;

public class PushEToInteract : MonoBehaviour
{
    public static UnityEvent<GameObject> OnPlayerInteractedWith = new UnityEvent<GameObject>();

    private GameObject detectedObject;
    private IInteractable interactableObject;

    private void OnEnable()
    {
        ObjectDetector.OnAnyObjectDetected.AddListener(SetDetectedInteractableObject);
    }
    private void OnDisable()
    {
        ObjectDetector.OnAnyObjectDetected.RemoveListener(SetDetectedInteractableObject);
    }

    private void Update()
    {
        InteractWithInteractableObject();
    }

    private void SetDetectedInteractableObject(GameObject detectedObjectByRaycast)
    {
        detectedObject = detectedObjectByRaycast;

        interactableObject = detectedObject.GetComponent<IInteractable>();
    }

    private void InteractWithInteractableObject()
    {
        if (interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact();

            // OnPlayerInteractedWith?.Invoke(detectedObject);
        }
    }
}