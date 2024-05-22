using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject coinPrefab;
    void SpawnCoin()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        float minX = collider.bounds.min.x + 1; // Adjusted minimum X position
        float maxX = collider.bounds.max.x - 1; // Adjusted maximum X position
        float minZ = collider.bounds.min.z + 1; // Adjusted minimum Z position
        float maxZ = collider.bounds.max.z - 1; // Adjusted maximum Z position

        Vector3 point = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(minZ, maxZ)
        );

        point.y = 1;
        return point;
    }

    Vector3 GetRandomPointInCollider2(Collider collider)
    {
        float minX = collider.bounds.min.x + 1; // Adjusted minimum X position
        float maxX = collider.bounds.max.x - 1; // Adjusted maximum X position
        float minZ = collider.bounds.min.z + 1; // Adjusted minimum Z position
        float maxZ = collider.bounds.max.z - 1; // Adjusted maximum Z position

        Vector3 point = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(minZ, maxZ)
        );

        point.y = 0.2f;
        return point;
    }


    public GameObject rock_1_Prefab;
    public GameObject rock_5_Prefab;
    public GameObject rock_4_Prefab;

    public GameObject tree_1_Prefab;
    public GameObject log_1_Prefab;

    public GameObject powerUp1;
    public GameObject enemyObstacle1;

    GameObject[] obstacles;

    void SpawnObstacle()
    {
        obstacles = new GameObject[] {rock_1_Prefab, rock_5_Prefab, rock_4_Prefab, tree_1_Prefab, log_1_Prefab, powerUp1, enemyObstacle1 };
        int obstacleToSpawn = Random.Range(0, 6);
        for (int i = 0; i < obstacleToSpawn; i++)
        {
            GameObject tempPrefab = obstacles[Random.Range(0, obstacles.Length)];
            GameObject temp = Instantiate(tempPrefab);
            temp.transform.position = GetRandomPointInCollider2(GetComponent<Collider>());
        }
    }
}
