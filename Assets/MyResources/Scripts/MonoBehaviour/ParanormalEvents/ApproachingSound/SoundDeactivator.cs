using UnityEngine;

public class SoundDeactivator : MonoBehaviour
{
    private Transform soundContainer;

    private void Awake()
    {
        soundContainer = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        DeactivateAllSounds();
    }

    private void DeactivateAllSounds()
    {
        foreach (Transform s in soundContainer)
        {
            s.gameObject.SetActive(false);
        }
    }
}