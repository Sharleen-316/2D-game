using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // # Health
    public int health = 1;

    // # Timer for how long the player is invulnerable for
    float invulnTimer = 0;

    // # Determines if object is a Player or Enemy
    int correctLayer;

    public float invulnPeriod = 0;

    void Start()
    {
        // # Assigns the layer to the correctLayer variable
        correctLayer = gameObject.layer;
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
        invulnTimer -= Time.deltaTime;

        // # Changes the object's state back to default once timer has run out
        if(invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
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
