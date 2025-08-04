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

    public float rightCarSpawnInterval;
    public float leftCarSpawnInterval;
    public float sideObstacleSpawnInterval;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 5.5f;

    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitUntil(() => GameManagerScript.spawnObjects);
        StartCoroutine(SpawnCarLeftPrefab());
        StartCoroutine(SpawnCarRightPrefab());
        StartCoroutine(SpawnSideObstaclePrefab());
    }

    IEnumerator SpawnCarLeftPrefab()
    {
        while (true)
        {
            leftCarSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            // Debug.Log("------------------------------------------------");
            // Debug.Log("leftCarSpawnInterval: " + leftCarSpawnInterval);
            // Debug.Log("------------------------------------------------");

            GameObject prefabToSpawn;
            Vector3 spawnPosition;

            int index = Random.Range(0, carLeftPrefabs.Length);
            prefabToSpawn = carLeftPrefabs[index];
            spawnPosition = new Vector3(carLeftXPosition, fixedYBottomPosition, 0f);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(leftCarSpawnInterval);
        }
    }
    IEnumerator SpawnCarRightPrefab()
    {
        while (true)
        {
            rightCarSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            // Debug.Log("------------------------------------------------");
            // Debug.Log("rightCarSpawnInterval: " + rightCarSpawnInterval);
            // Debug.Log("------------------------------------------------");

            GameObject prefabToSpawn;
            Vector3 spawnPosition;

            int index = Random.Range(0, carRightPrefabs.Length);
            prefabToSpawn = carRightPrefabs[index];
            spawnPosition = new Vector3(carRightXPosition, fixedYPosition, 0f);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(rightCarSpawnInterval);
        }
    }
    IEnumerator SpawnSideObstaclePrefab()
    {
        while (true)
        {
            sideObstacleSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            // Debug.Log("------------------------------------------------" );
            // Debug.Log("sideObstacleSpawnInterval: " + sideObstacleSpawnInterval);
            // Debug.Log("------------------------------------------------" );

            GameObject prefabToSpawn;
            Vector3 spawnPosition;

            int index = Random.Range(0, prefabs.Length);
            prefabToSpawn = prefabs[index];
            bool isBuilding = prefabToSpawn.CompareTag("obstacle-building");
            int xIndex = isBuilding ? Random.Range(0, spawnXPositionsBuildings.Length) : Random.Range(0, spawnXPositions.Length);
            float xPos = isBuilding ? spawnXPositionsBuildings[xIndex] : spawnXPositions[xIndex];

            spawnPosition = new Vector3(xPos, fixedYPosition, 0f);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(sideObstacleSpawnInterval);
        }
    }
}
