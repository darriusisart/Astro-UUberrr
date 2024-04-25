using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(1.0f, 1.0f);
    public int health = 3; // Starting health
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Rigidbody2D rigidbody2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    public GameObject laserPrefab; // Reference to the laser prefab

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
        rigidbody2D.isKinematic = true;
    }
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed");
            ShootLaser();
        }
    }


    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
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
    void ShootLaser()
    {
        if (laserPrefab != null)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Debug.Log("Laser shot");
        }
        else
        {
            Debug.Log("Laser prefab is not assigned");
        }
    }

}
