using UnityEngine;

public class SoundPositionGenerator
{
    public Vector3 NewSpawnApproachinSoundPosition(Transform playerTransform, float spawnDistance, float spawnAngle)
    {
        Vector3 playerPosition = playerTransform.position;

        Vector3 backPlayerView = playerTransform.forward * -1;
        backPlayerView.y = 0;

        float randomAngleBehindPlayer = Random.Range(-spawnAngle, spawnAngle);

        Vector3 spawnDirection = Quaternion.AngleAxis(randomAngleBehindPlayer, Vector3.up) * backPlayerView;

        Vector3 newSoundPosition = playerPosition + spawnDirection * spawnDistance;

        return newSoundPosition;
    }
}