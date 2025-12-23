using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // # Offset for the position of the bullet (ensures bullets don't spawn from the middle of the ship)
    public Vector3 bulletOffset = new Vector3(0, 0.75f, 0);

    // # Reference to the bullet
    public GameObject bulletPrefab;

    // # Delay between firings
    public float fireDelay = 0.25f;

    // # Cooldown period that occurs after player shoots
    float cooldownTimer = 0;

    // # Layer bullet should spawn on
    int bulletLayer;

    // # Reference to transform of player
    Transform player;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            // # Find player ship
            GameObject playerObject = GameObject.Find("PlayerShip");

            if(playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        // # Decreases the timer each frame
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4)
        {
            // # Shoot
            Debug.Log("Pew!"); // # Debug message
            cooldownTimer = fireDelay; // # Resets the timer
            Vector3 offset = transform.rotation * bulletOffset; // # Sets transform of the bullet
            GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation); // # Spawns the bullet
            bulletObject.layer = bulletLayer;
        }
    }
}
