using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // # Reference to player ship
    public GameObject playerPrefab;
    GameObject playerInstance;

    // # Time between player death and respawn
    float respawnTimer = 1f;

    public int numLives = 4; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // # Spawns player at the start of the same
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // # Decreases amount of lives player has
        numLives--;

        if(numLives > 0)
        {
            // # Resets the respawn timer
            respawnTimer = 1;

            // # Creates a new instance of the player and places it in the world
            playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity); // // Quaternion.identity = 0 rotation

            // # Changes gameObject name for debugging reasons
            playerInstance.name = "PlayerShip";
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(playerInstance == null && numLives > 0)
        {
            // # Decreases the respawn timer
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0)
            {
                // # Respawns the player when the timer has reached 0
                SpawnPlayer();
            }

            //SpawnPlayer();
        } 
        
    }

    void OnGUI()
    {
        if(numLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
        }
        else
        {
           GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 -25, 100, 50), "Game Over!"); 
        }
    }
}
