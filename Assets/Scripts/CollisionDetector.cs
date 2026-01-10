using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public Transform playerSpawner;
    void OnTriggerEnter2D()
    {
        Debug.Log("Score!");
    }
}
