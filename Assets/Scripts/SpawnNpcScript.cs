using System.Collections;
using UnityEngine;

public class SpawnNpcScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public float frontNpcSpawnInterval;
    public float frontNpcSpawnMin = 4f;
    public float frontNpcSpawnMax = 4.5f;
    public float[] spawnXPositions;
    public float fixedYPosition = 5f;
    public GameObject[] prefabs;


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
            frontNpcSpawnInterval = Random.Range(frontNpcSpawnMin, frontNpcSpawnMax); 
            // Debug.Log("SPAWN frontNpcSpawnMin: " + frontNpcSpawnMin);
            // Debug.Log("SPAWN frontNpcSpawnMax: " + frontNpcSpawnMax); 
            // Debug.Log("SPAWN frontNpcSpawnInterval: " + frontNpcSpawnInterval);
            // Debug.Log("--------------------------------------------------------");
            int index = Random.Range(0, spawnXPositions.Length);
            Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);
            int prefabIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(frontNpcSpawnInterval);
        }

        // TODO REVISIT INCREASING THE NUMBER OF SPAWNED NPCS BASED ON MILESTONE - CURRENTLY TOO MANY
        // while (true)
        // {
        //     int spawnCount = globalVariables.currentLevel;
        //     // Debug.Log("spawn count / level: " + spawnCount);
        //     for (int i = 0; i < spawnCount; i++)
        //     {
        //         // create the prefab at a random spawn point
        //         int index = Random.Range(0, spawnXPositions.Length);
        //         Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);

        //         // select a random prefab from prefab index range
        //         int prefabIndex = Random.Range(0, prefabs.Length);
        //         Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);
        //     }
        //     // wait for the next spawn interval
        //     yield return new WaitForSeconds(globalVariables.commonNpcSpawnInterval);
        // }
    }

}
