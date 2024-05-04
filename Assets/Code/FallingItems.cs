using UnityEngine;

public class FallingItems : MonoBehaviour
{
    public Sprite[] possibleSprites;
    public GameObject fallingItemPrefab;
    public float spawnInterval = 1.0f;
    public float spawnHeight = 20.0f;
    public float spawnRangeX = 14.0f;
    public float minRotation = -45f;
    public float maxRotation = 45f;
    public float minHorizontalSpeed = -2.0f;
    public float maxHorizontalSpeed = 2.0f;
    public int maxSpawnedItems = 10;
    private int currentSpawnedItems = 0;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentSpawnedItems < maxSpawnedItems)
        {
            SpawnItem();
            timer = 0f;
        }

        GameObject[] spawnedItems = GameObject.FindGameObjectsWithTag("FallingItem");
        currentSpawnedItems = spawnedItems.Length;
    }

    private void SpawnItem()
    {
        if (possibleSprites.Length == 0)
        {
            return;
        }

        Sprite spriteToUse = possibleSprites[Random.Range(0, possibleSprites.Length)];
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0.0f);

        GameObject newFallingItem = Instantiate(fallingItemPrefab, spawnPosition, Quaternion.identity);

        // Check if SpriteRenderer component exists, if not, add one
        SpriteRenderer spriteRenderer = newFallingItem.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = newFallingItem.AddComponent<SpriteRenderer>();
        }

        // Assign the sprite
        spriteRenderer.sprite = spriteToUse;

        float randomRotation = Random.Range(minRotation, maxRotation);
        newFallingItem.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

        // Check if Rigidbody2D component exists, if not, add one
        Rigidbody2D rb = newFallingItem.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = newFallingItem.AddComponent<Rigidbody2D>();
        }

        // Set the horizontal speed
        float horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
        rb.velocity = new Vector2(horizontalSpeed, 0f);
    }
}
