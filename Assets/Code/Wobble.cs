using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    public float wobbleAngle = 10f; 
    public float wobbleSpeed = 5f; 
    public Color blinkColor = Color.red; 
    public float blinkDuration = 0.1f; 
    public int blinkCount = 3;
    public float immunityDuration = 1f;

    private bool isImmune = false;
    private bool isColliding = false;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Rotate player to create wobbling effect
        if (isColliding)
        {
            float angle = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAngle;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.identity; // Reset rotation when not colliding
        }
    }

    private IEnumerator BlinkEffect()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.color = blinkColor;
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
    
    private IEnumerator ImmunityCooldown()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDuration);
        isImmune = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingItem"))
        {
            isColliding = true;
            StartCoroutine(BlinkEffect());
            StartCoroutine(ImmunityCooldown());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingItem"))
        {
            isColliding = false;
        }
    }
}
