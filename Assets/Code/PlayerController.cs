using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(1.0f, 1.0f);
    public int health = 3; // Starting health
    private Rigidbody2D rigidbody2D;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Add a BoxCollider2D if it's not already added
        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        // Ensure the Rigidbody2D properties are set to prevent wobbling
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.isKinematic = true; // Prevents physics from affecting the player
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        // Move the player based on input
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // Reduce health by 1
            health--;

            // Print feedback
            Debug.Log("Player collided with an item!");

            // Check if health is zero and destroy the player if so
            if (health <= 0)
            {
                Debug.Log("Player's health reached zero. Destroying player...");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player's health decreased to: " + health);
            }
        }
    }
}
