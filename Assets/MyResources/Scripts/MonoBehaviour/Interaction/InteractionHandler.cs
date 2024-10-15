using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private IInteractable cachedInteractableObject;

    private void Update()
    {
        Interact();
    }

    public void HandleInteraction(IInteractable interactable)
    {
        if (interactable != null)
        {
            cachedInteractableObject = interactable;
        }

        Interact();
    }

    private void Interact()
    {
        if (cachedInteractableObject != null && Input.GetKey(KeyCode.E))
        {
            cachedInteractableObject.Interact();
        }
    }
}