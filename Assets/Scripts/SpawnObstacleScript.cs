using System.Collections;
using UnityEngine;

public class SpawnObstacleScript : MonoBehaviour
{

    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    // public float commonObstacleSpawnInterval = 4f;
    public float[] spawnXPositions;
    public float[] spawnXPositionsBuildings;
    public float carRightXPosition;
    public float carLeftXPosition;


    public float fixedYPosition;
    public float fixedYBottomPosition;


    // create an array of random prefabs to spawn
    public GameObject[] prefabs;
    public GameObject[] carRightPrefabs;
    public GameObject[] carLeftPrefabs;


    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitUntil(() => GameManagerScript.spawnObjects);
        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            bool spawnCarRight = Random.value < 0.4f;
            bool spawnCarLeft = Random.value < 0.4f;
            bool spawnPowerline = Random.value < 0.4f;
            bool isBuilding = tag == "obstacle-building";

            GameObject prefabToSpawn;
            Vector3 spawnPosition;

            if (spawnCarRight)
            {
                // Debug.Log("spawnCarRight");
                int index = Random.Range(0, carRightPrefabs.Length);
                prefabToSpawn = carRightPrefabs[index];
                spawnPosition = new Vector3(carRightXPosition, fixedYPosition, 0f);
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }
            if (spawnCarLeft)
            {
                // Debug.Log("spawnCarLeft");
                int index = Random.Range(0, carLeftPrefabs.Length);
                prefabToSpawn = carLeftPrefabs[index];
                spawnPosition = new Vector3(carLeftXPosition, fixedYBottomPosition, 0f);
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }
            if (spawnPowerline)
            {
                // Debug.Log("spawnPowerline");
                int index = Random.Range(0, prefabs.Length);
                prefabToSpawn = prefabs[index];
                int xIndex = isBuilding ? Random.Range(0, spawnXPositionsBuildings.Length) : Random.Range(0, spawnXPositions.Length);
                float xPos = isBuilding ? spawnXPositionsBuildings[xIndex] : spawnXPositions[xIndex];
                Debug.Log("++++++++++++++++++++++++++++++++++++++");
                Debug.Log("isBuilding: " + isBuilding);
                Debug.Log("++++++++++++++++++++++++++++++++++++++");
                // if (tag == "obstacle")
                // {
                //     int xIndex = Random.Range(0, spawnXPositions.Length);
                //     // float xPos = spawnXPositions[xIndex];
                // }
                // else if (tag == "obstacle-building")
                // {
                //     int xIndex = Random.Range(0, spawnXPositionsBuildings.Length);
                //     // float xPos = spawnXPositionsBuildings[xIndex];
                // }

                spawnPosition = new Vector3(xPos, fixedYPosition, 0f);
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }

            // Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(globalVariables.commonObstacleSpawnInterval);
        }
    }
}
