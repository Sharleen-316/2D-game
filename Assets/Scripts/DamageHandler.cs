using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // # Health
    public int health = 1;

    // # Timer for how long the player is invulnerable for
    float invulnTimer = 0;

    // # Determines if object is a Player or Enemy
    int correctLayer;

    // # Amount of time object is allowed to be invulnerable for
    public float invulnPeriod = 0;

    // # Player flashing variabeles
    SpriteRenderer spriteRend; // # Reference to sprite renderer

    void Start()
    {
        // # Assigns the layer to the correctLayer variable
        correctLayer = gameObject.layer;

        // ! Only gets the sprite renderer on the parent object
        spriteRend = GetComponent<SpriteRenderer>();
        if(spriteRend == null)
            {
                // // Gets sprite renderer of the children objects
                spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
                
                if (spriteRend== null)
            {
                Debug.LogError("Object " + gameObject.name + " has no sprite rendered");
            }
            }
    }

    void OnTriggerEnter2D()
    {
        // # Debug message
        Debug.Log("Trigger!");

        // # Decreases health and puts object in invulnerable state
        health--;
        if(invulnPeriod > 0){
            invulnTimer = invulnPeriod;
            gameObject.layer = 7;
        }
    }

    void Update()
    {
        // # Decreases invulnerable timer
        if(invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            // # Changes the object's state back to default once timer has run out
            if(invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;

                if(spriteRend!= null)
                {
                   spriteRend.enabled = true; 
                }

            } else
            {
                if(spriteRend!= null)
                {
                   spriteRend.enabled = !spriteRend.enabled; 
                }
            }
        }

        // # Calls die function if health is lower than or equal to 0
        if(health <= 0)
        {
            Die();
        }
    }

    // # Destroys the enemy ship
    void Die()
    {
        Destroy(gameObject);
    }
}
