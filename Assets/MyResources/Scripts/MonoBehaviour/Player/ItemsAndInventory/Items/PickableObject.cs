using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SphereCollider))]
public class PickableObject : MonoBehaviour, IPickableObject
{
    public PickableItem pickableItemParameters;

    private SphereCollider sphereCollider;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.radius = pickableItemParameters.SphereColliderRadius;
        sphereCollider.isTrigger = pickableItemParameters.IsSphereColliderTrigger;
    }

    public void DestroyOnPickedUp()
    {
        Destroy(gameObject);
    }
}