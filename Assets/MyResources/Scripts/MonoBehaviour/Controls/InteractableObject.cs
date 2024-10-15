using System.Collections.Generic;
using UnityEngine;

public class PressEToIneract : ObjectDetector
{
    protected Dictionary<Collider, IInteractable> cachedDetectedObjects = new Dictionary<Collider, IInteractable>();

    private IInteractable pickupPickableObject;

    private void Awake()
    {
        pickupPickableObject = GetComponent<IInteractable>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) pickupPickableObject.Interact();
        if (Input.GetKeyUp(KeyCode.E)) pickupPickableObject.Interact();
    }

    public PressEToIneract(CameraRayProvider cameraRayProvider, float detectionRayLenght)
        : base(cameraRayProvider, detectionRayLenght) { }

    protected override void ProcessHit(Collider hittedCollider)
    {
        if (cachedDetectedObjects.TryGetValue(hittedCollider, out IInteractable detectedInteractableObject) && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyUp(KeyCode.E)))
        {
            detectedInteractableObject.Interact();
        }
        else
        {
            detectedInteractableObject = hittedCollider.GetComponent<IInteractable>();

            if (detectedInteractableObject != null)
            {
                detectedInteractableObject.Interact();
                cachedDetectedObjects[hittedCollider] = detectedInteractableObject;
            }
        }
    }
}
