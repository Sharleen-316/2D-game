using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float enemyRate = 5;
    float nextEnemy = 1;
    float spawnDistance = 20f;
    

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;

            if(enemyRate< 2)
            {
                enemyRate = 2;
            }

            Vector3 offset = Random.onUnitSphere; // // Creates a random vector where the numbers in x,y,z can go from -1 to 1

            offset.z = 0;
            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
        
    }
}
