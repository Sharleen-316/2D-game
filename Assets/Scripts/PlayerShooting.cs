using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // # Offset for the position of the bullet (ensures bullets don't spawn from the middle of the ship)
    public Vector3 bulletOffset = new Vector3(0, 0.75f, 0);

    // # Reference to the bullet
    public GameObject bulletPrefab;

    // # Delay between firings
    public float fireDelay = 0.25f;

    // # Cooldown period that occurs after player shoots
    float cooldownTimer = 0;

    // # Layer of bullet
    int bulletLayer;

    void Start()
    {
        // # Initalises bulletLayer to equal the layer the game object is on at the start of the game
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        // # Decreases the timer each frame
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0) // ! Go to Input Manager in Unity Project Settings and change this from spacebar to enter also change GetButton to GetButtonDown
        {
            // # Shoot
            Debug.Log("Pew!"); // # Debug message
            cooldownTimer = fireDelay; // # Resets the timer
            Vector3 offset = transform.rotation * bulletOffset; // # Sets transform of the bullet
            GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation); // # Spawns the bullet
            bulletObject.layer = bulletLayer; // # Sets the bullet to spawn on the correct layer to avoid enemies shooting each other
        }
    }
}
