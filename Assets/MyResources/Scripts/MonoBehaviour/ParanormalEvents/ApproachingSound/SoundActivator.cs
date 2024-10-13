using System.Collections;
using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    private Transform soundContainer;
    [SerializeField] int minRandomSpawnTime = 3;
    [SerializeField] int maxRandomSpawnTime = 6;

    Coroutine activatorCoroutine;

    private void Awake()
    {
        soundContainer = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        activatorCoroutine = StartCoroutine(RandomTimeSoundActivator());
    }
    private void OnDisable()
    {
        StopCoroutine(activatorCoroutine);
    }

    private IEnumerator RandomTimeSoundActivator()
    {
        while (true)
        {
            int randomSpawnTime = Random.Range(minRandomSpawnTime, maxRandomSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);

            ActivateRandomSound();
        }
    }

    private void ActivateRandomSound()
    {
        int index = Random.Range(0, soundContainer.childCount);
        GameObject sound = soundContainer.GetChild(index).gameObject;
        sound.SetActive(true);
    }
}