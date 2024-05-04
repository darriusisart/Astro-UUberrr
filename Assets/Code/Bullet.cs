using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Item"))
        {
            // Destroy both objects
            Debug.Log("Collided");
            Destroy(gameObject); // Destroy the object this script is attached to
            Destroy(collision.gameObject); // Destroy the collided object
        }
    }
}
