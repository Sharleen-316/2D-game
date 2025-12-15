using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
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
        Vector3 dir = player.position - transform.position; // # Points to player
    }
}
