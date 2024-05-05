using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public int maxHealth = 3; // Maximum health of the player
    public int health; // Current health of the player

    void Start()
    {
        // Initialize health to match the player's starting health
        health = maxHealth;
    }

    void Update()
    {
        // Sync the health of the ItemDestroyer with the player's health
        health = player.GetComponent<PlayerController>().maxHealth;

        // Destroy the ItemDestroyer if the player's health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

