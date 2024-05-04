using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRate = 1f;
    public Vector2 spawnAreaCenter;
    public Vector2 spawnAreaSize;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnObject()
    {
        Vector2 randomPosition = GetRandomPosition();
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);

        return new Vector2(randomX, randomY);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}
