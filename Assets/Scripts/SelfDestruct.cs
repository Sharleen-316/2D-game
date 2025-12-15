using System.Threading;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // # Timer for when it should destory itself
    public float timer = 1f;

    // Update is called once per frame
    void Update()
    {
        // # Gradually decreases the time each frame
        timer -= Time.deltaTime;

        // # Destroys itself once the timer has finished
        if(timer <= 0)
        {
           Destroy(gameObject);
        }
    }
}
