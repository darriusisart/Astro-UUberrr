using UnityEngine;

public class LaserDetection : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("Hello, Script has been called");
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
