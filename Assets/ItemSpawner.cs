using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items; // Array to hold the different items to spawn
    public float spawnInterval = 2f; // Interval between each spawn
    public float minX = -5f; // Minimum X position for spawning
    public float maxX = 5f; // Maximum X position for spawning
    public float spawnHeight = 10f; // Height from which items will spawn

    private float timer; // Timer to track spawn interval

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn an item
        if (timer >= spawnInterval)
        {
            // Reset timer
            timer = 0f;

            // Spawn a random item
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // Get a random item from the items array
        GameObject randomItem = items[Random.Range(0, items.Length)];

        // Generate a random position within the specified range
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        // Instantiate the random item at the generated position
        Instantiate(randomItem, spawnPosition, Quaternion.identity);

        // Debug log to check if the method is being called
        Debug.Log("Item spawned at position: " + spawnPosition);
    }

}
