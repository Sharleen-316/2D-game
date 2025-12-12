using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // # Max speed player can move
    public float maxSpeed;

    // # Rotation speed
    public float rotSpeed;

    // # Boundaries variables
    float shipBoundaryRadius = 0.49f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // // Best for dealing with inputs --> functions like GetKeyDown see if a key was hit at a specific frame for the first time (won't repeat)
    // // GetButton needs an actual string that represents key mappings
    void Update()
    {
        // // Returns a float between -1.0 and 1.0 depends on direction
        // ? Input.GetAxis("Vertical");

        // # Rotates player for reference
        // // Quaternions are a way of tracking rotations while avoiding a bunch of problems, deep math apparently. 
        // // Good for True representations of rotations but hard to work with manually
        // // Quaternions have x,y,z, and w
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z; // // Getting z directly (e.g., without the eulerAngles part) returns a different result
        z += -Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime; // # Rotates player along the z axis
        rot = Quaternion.Euler(0, 0, z); // # Recreate quaternion
        transform.rotation = rot; // # Assign quaternion to rotation

        // // Can't write directly to .position anything in C# (even though I swear I did in previous projects)
        // # Makes the player move left and right
        Vector3 pos = transform.position;
        //pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime; // // Allows us to control the speed the player is moving

        // # Forward and backward movement for reference but I'm not including it in this game
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity; // // Quaternion has to come first in this instance

        // # Restrict player to screen's boundaries (for reference, not planning on using this)
        // // Establishes y boundaries by checking if the player has reached the top/bottom of the screen
        // // Done by using the camera size
        if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize) // // "Camera.main" refers to the camera with the MainCamera tag on it
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if(pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) // // "Camera.main" refers to the camera with the MainCamera tag on it
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        // // Calculates the camera's orthographic width by getting the screen ratio
        float screenRatio = (float)Screen.width/(float)Screen.height; // ! Will be weird? Boundaries become weird sizes due to doing dividing an integer by an integer (returns an integer when the actual result is a float)
        float widthOrtho = Camera.main.orthographicSize * screenRatio;


        // // Calculates horizontal bounds using the orthographic width
        if(pos.x + shipBoundaryRadius > widthOrtho) // // "Camera.main" refers to the camera with the MainCamera tag on it
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if(pos.x - shipBoundaryRadius < -widthOrtho) // // "Camera.main" refers to the camera with the MainCamera tag on it
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        // # Update position
        transform.position = pos;
    }
}
