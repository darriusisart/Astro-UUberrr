using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed = 1000000f;        // Speed of the laser
    public float lifetime = 5f;      // Lifetime of the laser before auto-destruction

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
            // Assumes the laser's 'up' is the forward direction
        }

        Destroy(gameObject, lifetime); // Destroys the laser after a set amount of time
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Add tag checks here depending on what your laser should interact with, e.g., "Enemy"
        if (other.CompareTag("Item"))
        {
            // Here you could add effects like damage to the enemy, play sounds, etc.
            Debug.Log("Laser hit the item!");

            // Destroy the laser upon collision
            Destroy(gameObject);
        }
    }
}
