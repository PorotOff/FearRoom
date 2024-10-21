using UnityEngine;

public class DeactivateApproachingSound : MonoBehaviour, IDetectable
{
    [SerializeField] private GameObject endSoundPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Deactivate();
        }
    }

    public void OnDetected()
    {
        Deactivate();
    }
    public void OnDetected(GameObject detectedObject)
    {
        throw new System.NotImplementedException();
    }

    private void Deactivate()
    {
        SpawEndSound();
        gameObject.SetActive(false);
    }

    private void SpawEndSound()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(endSoundPrefab, spawnPosition, Quaternion.identity);
    }
}