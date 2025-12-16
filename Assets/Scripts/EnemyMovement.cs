using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // # Reference to transform of player
    Transform player;

    // # Speed of rotation
    public float rotSpeed = 180f;


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

        // # Exits and tries finding the player in the next frame if player hasn't been found
        if(player == null)
        {
            // # Try again next frame
            return;
        }

        // # Turn to face player if its has been found
        Vector3 dir = player.position - transform.position; // # Gets the distance between player and enemy
        dir.Normalize(); // # Ensure the distance equals 1

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // # Gets the angle the enemy have in order to face the player

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle); // # Sets the new rotation

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime); // # Sets the speed of the rotation
    }
}
