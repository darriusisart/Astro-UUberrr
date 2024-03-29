using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPassthrough : MonoBehaviour
{
    public string playerTag = "Player";

    void Start()
    {
        Collider2D borderCollider = GetComponent<Collider2D>();
        if(borderCollider == null)
        {
            Debug.LogError("No Collider2D component found on the border object.");
        }
        else
        {
            IgnoreCollisionsWithNonPlayers(borderCollider);
        }
    }

    private void IgnoreCollisionsWithNonPlayers(Collider2D borderCollider)
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D collider in allColliders)
        {
            if (collider != borderCollider)
            {
                if (collider.CompareTag(playerTag))
                {
                    Physics2D.IgnoreCollision(borderCollider, collider, false);
                }
                else if (collider.CompareTag("FallingItem"))
                {
                    Physics2D.IgnoreCollision(borderCollider, collider, true);
                }
            }
        }
    }
}