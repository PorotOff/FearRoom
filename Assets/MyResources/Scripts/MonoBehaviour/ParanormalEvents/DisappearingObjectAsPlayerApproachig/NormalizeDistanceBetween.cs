using UnityEngine;

public class NormalizeDistanceBetween : MonoBehaviour
{
    private PlayerStayInCollider playerStayInCollider;

    private void Awake()
    {
        playerStayInCollider = GetComponent<PlayerStayInCollider>();
    }

    public float GetNormalisedDistance()
    {
        if (playerStayInCollider.PlayerTransform != null)
        {
            Vector3 currentObjectPosition = gameObject.transform.position;
            Vector3 maxPlayerPosition = playerStayInCollider.FirstTouch;
            Vector3 playerPosition = playerStayInCollider.PlayerTransform.position;

            float maxDistance = Vector3.Distance(currentObjectPosition, maxPlayerPosition);
            float currentDistance = Vector3.Distance(currentObjectPosition, playerPosition);

            return Mathf.InverseLerp(0, maxDistance, currentDistance);
        }

        return 1f;
    }
}