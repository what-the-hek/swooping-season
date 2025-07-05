using System.Collections;
using UnityEngine;

public class SpawnObstacleScript : MonoBehaviour
{

    public globalVariables globalVariables;
    // public float commonObstacleSpawnInterval = 4f;
    public float[] spawnXPositions;
    public float carRightXPosition = 1.25f;

    public float fixedYPosition = 5f;

    // create an array of random prefabs to spawn
    public GameObject[] prefabs;
    public GameObject[] carRightPrefabs;



    void Start()
    {
        // start a coroutine and spawn prefabs
        StartCoroutine(SpawnPrefab());
    }

    // part of the coroutine to respawn a prefab at random intervals depending on tag

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            bool spawnCarRight = Random.value < 0.3f;
            GameObject prefabToSpawn;
            Vector3 spawnPosition;

            if (spawnCarRight)
            {
                int index = Random.Range(0, carRightPrefabs.Length);
                prefabToSpawn = carRightPrefabs[index];
                spawnPosition = new Vector3(carRightXPosition, fixedYPosition, 0f);
            }
            else
            {
                int index = Random.Range(0, prefabs.Length);
                prefabToSpawn = prefabs[index];
                int xIndex = Random.Range(0, spawnXPositions.Length);
                float xPos = spawnXPositions[xIndex];
                spawnPosition = new Vector3(xPos, fixedYPosition, 0f);
            }

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(globalVariables.commonObstacleSpawnInterval);
        }
    }
}
