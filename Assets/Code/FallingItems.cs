using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItems : MonoBehaviour
{
    public Sprite[] possibleSprites; // Array of sprites to choose from
    public GameObject fallingItemPrefab; // Prefab of the falling item
    public float spawnInterval = 1.0f; // Interval between spawning items
    public float spawnHeight = 20.0f; // Height from which items are spawned
    public float spawnRangeX = 14.0f; // Range of x positions for spawning items
    public float minRotation = -45f; // Minimum rotation angle
    public float maxRotation = 45f; // Maximum rotation angle
    public float minHorizontalSpeed = -2.0f; // Minimum horizontal speed of falling items
    public float maxHorizontalSpeed = 2.0f; // Maximum horizontal speed of falling items
    public int maxSpawnedItems = 10; // Maximum number of items spawned at a time
    private int currentSpawnedItems = 0; // Current number of spawned items
    private float timer = 0f; // Timer for spawning items

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentSpawnedItems < maxSpawnedItems)
        {
            SpawnItem();
            timer = 0f;
        }

        // Check if any spawned items have been destroyed
        GameObject[] spawnedItems = GameObject.FindGameObjectsWithTag("FallingItem");
        currentSpawnedItems = spawnedItems.Length;
    }

    private void SpawnItem()
    {
        if (possibleSprites.Length == 0)
        {
            return; // No sprites available, don't spawn more items
        }

        // Randomly select a sprite
        Sprite spriteToUse = possibleSprites[Random.Range(0, possibleSprites.Length)];

        // Randomly select a position within the spawn range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0.0f);

        // Instantiate the falling item
        GameObject newFallingItem = Instantiate(fallingItemPrefab, spawnPosition, Quaternion.identity);

        // Set the sprite of the falling item
        SpriteRenderer spriteRenderer = newFallingItem.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = spriteToUse;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on the falling item prefab.");
        }

        // Randomly rotate the falling item
        float randomRotation = Random.Range(minRotation, maxRotation);
        newFallingItem.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

        // Randomly set horizontal speed
        Rigidbody2D rb = newFallingItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
            rb.velocity = new Vector2(horizontalSpeed, 0f);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the falling item prefab.");
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lazer") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("item has been hit");
            Destroy(gameObject);
        }
    }
}
