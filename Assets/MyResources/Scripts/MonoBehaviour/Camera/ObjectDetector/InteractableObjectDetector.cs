using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectDetector : RaycastObjectDetector
{
    protected Dictionary<Collider, IInteractable> cachedDetectedObjects = new Dictionary<Collider, IInteractable>();

    [SerializeField] private float fillingRate = 1f;
    private PushingTimer pushingTimer;

    protected override void Awake()
    {
        base.Awake();
        pushingTimer = new PushingTimer(fillingRate);
    }

    // private void OnEnable()
    // {
    //     pushingTimer.OnTimerFilled.AddListener(CallInteractionEvent);
    // }
    // private void OnDisable()
    // {
    //     pushingTimer.OnTimerFilled.RemoveListener(CallInteractionEvent);
    // }

    protected override void ProcessHit(Collider hittedCollider)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (cachedDetectedObjects.TryGetValue(hittedCollider, out IInteractable detectedObject))
            {
                detectedObject.Interact();

                Debug.Log($"E is pressed");
            }
            else
            {
                detectedObject = hittedCollider.GetComponent<IInteractable>();

                if (detectedObject != null)
                {
                    detectedObject.Interact();
                    cachedDetectedObjects[hittedCollider] = detectedObject;

                    Debug.Log($"E is pressed 2");
                }
            }
        }
    }
}