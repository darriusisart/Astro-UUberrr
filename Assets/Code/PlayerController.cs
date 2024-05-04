using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(1.0f, 1.0f);
    public int health = 3; // Starting health
    private Rigidbody2D rigidbody2D;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    private BoxCollider2D boxCollider;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.isKinematic = true;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        Vector2 movement = inputVector * MovementSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = rigidbody2D.position + movement;

        // Get the screen bounds in world coordinates
        Vector3 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Adjust the player's position to wrap around the screen
        if (newPosition.x < minScreenBounds.x - (boxCollider.size.x / 2))
        {
            newPosition.x = maxScreenBounds.x + (boxCollider.size.x / 2);
        }
        else if (newPosition.x > maxScreenBounds.x + (boxCollider.size.x / 2))
        {
            newPosition.x = minScreenBounds.x - (boxCollider.size.x / 2);
        }

        if (newPosition.y < minScreenBounds.y - (boxCollider.size.y / 2))
        {
            newPosition.y = maxScreenBounds.y + (boxCollider.size.y / 2);
        }
        else if (newPosition.y > maxScreenBounds.y + (boxCollider.size.y / 2))
        {
            newPosition.y = minScreenBounds.y - (boxCollider.size.y / 2);
        }

        // Apply the adjusted position to the player's Rigidbody
        rigidbody2D.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            health--;

            Debug.Log("Player collided with an item!");

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
