using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPickableObject : MonoBehaviour, IInteractable
{
    private List<PickableObject> pickableObjects = new List<PickableObject>();

    [SerializeField] private float pickupDelay = 1f;
    private Coroutine pickupCoroutine;

    private Inventory inventory;

    private bool isObjectPickingUp = false;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PickableObject pickableObject = other.GetComponent<PickableObject>();

        if (pickableObject != null)
        {
            pickableObjects.Add(pickableObject);

            // Debug.Log($"Pickable object added to pickableObjects");

            // foreach (var obj in pickableObjects)
            // {
            //     Debug.Log($"Pibckable objects[{obj.name}]");
            // }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PickableObject pickableObject = other.GetComponent<PickableObject>();

        if (pickableObject != null)
        {
            pickableObjects.Remove(pickableObject);

            // Debug.Log($"Pickable object removed from pickableObjects");

            // foreach (var obj in pickableObjects)
            // {
            //     Debug.Log($"Pibckable objects[{obj.name}]");
            // }
        }
    }

    public void Interact()
    {
        if (!isObjectPickingUp)
        {
            StartPickup();
        }
        else
        {
            StopPickup();
        }
    }

    private void StartPickup()
    {
        if (pickableObjects.Count > 0)
        {
            pickupCoroutine = StartCoroutine(Pickup());
        }
    }
    private void StopPickup()
    {
        StopCoroutine(pickupCoroutine);
    }

    private IEnumerator Pickup()
    {
        for (int i = 0; i < pickableObjects.Count; i++)
        {
            yield return new WaitForSeconds(pickupDelay);

            inventory.AddItem(pickableObjects[i].pickableItemParameters);

            pickableObjects[i].DestroyOnPickedUp();

            pickableObjects.Remove(pickableObjects[i]);
        }
    }
}