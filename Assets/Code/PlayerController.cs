using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(1.0f, 1.0f);
    public int maxHealth = 3; // Maximum health
    private int health; // Current health
    private Rigidbody2D rigidbody2D;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    private BoxCollider2D boxCollider;
    private Vector3 initialPosition;
    public GameObject[] healthIcons; // Array of health icons

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        initialPosition = transform.position;

        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.isKinematic = true;

        health = maxHealth;

        // Initialize health icons array
        healthIcons = GameObject.FindGameObjectsWithTag("HealthIcon");
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
            TakeDamage(collision.gameObject);
        }
    }

    public void TakeDamage(GameObject item)
    {
        health--;

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player's health reached zero.");

            if (!CheckGameOver())
            {
                Respawn();
            }
        }
        else
        {
            Debug.Log("Player's health decreased to: " + health);

            // Deactivate a health icon
            if (healthIcons.Length > 0)
            {
                healthIcons[health].SetActive(false);
            }
        }

        DestroyItemAfterDamage(item);
    }

    void DestroyItemAfterDamage(GameObject item)
    {
        ItemDestroyer destroyer = item.GetComponent<ItemDestroyer>();
        if (destroyer != null)
        {
          // destroyer.TakeDamage();
        }
    }

    void Respawn()
    {
        health = maxHealth;
        transform.position = initialPosition;
        Debug.Log("Player respawned.");
    }

    bool CheckGameOver()
    {
        if (health <= 0)
        {
            Debug.Log("Game over! Player lost all lives.");
            SceneManager.LoadScene("GameOverScene");
            return true;
        }
        return false;
    }
}
