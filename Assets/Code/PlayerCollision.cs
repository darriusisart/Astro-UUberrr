using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    private int health = 10;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Item")){
            health--;
            Debug.Log("Player Health: " + health);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("Health: "+ health);
        if (health < 0){
            Destroy(this.gameObject);
            Debug.Log("Player is dead");
        }
    }
}
