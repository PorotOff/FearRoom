using UnityEngine;

public class PlaceSoundBehindPlayer : MonoBehaviour
{
    private SoundPositionGenerator soundPositionGenerator;

    private Transform playerTransform;

    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float spawnAngle = 90f;

    private void Awake()
    {
        soundPositionGenerator = new SoundPositionGenerator();

        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void OnEnable()
    {
        PlaceBehind();
    }

    private void PlaceBehind()
    {
        transform.position = soundPositionGenerator.NewSpawnApproachinSoundPosition(playerTransform, spawnDistance, spawnAngle);
    }
}