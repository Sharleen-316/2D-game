using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // // Best for dealing with inputs --> functions like GetKeyDown see if a key was hit at a specific frame for the first time (won't repeat)
    // // GetButton needs an actual string that represents key mappings
    void Update()
    {
        // # Returns a float between -1.0 and 1.0 depends on direction
        Input.GetAxis("Vertical");

        // // Can't write directly to .position anything in C# (even though I swear I did in previous projects)
        // # Makes the player move forward
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical");
        transform.position = pos;
    }
}
