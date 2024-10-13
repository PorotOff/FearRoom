using System.Collections;
using UnityEngine;

public class DisableEndSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(DisableAfterPlayedSound());
    }

    private IEnumerator DisableAfterPlayedSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        Destroy(gameObject);
    }
}