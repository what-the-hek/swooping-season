using System.Collections;
using UnityEngine;

public class SpawnNpcScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    // public LevelManagerScript levelManager;
    public float frontNpcSpawnInterval;
    public float frontNpcSpawnMin = 3.5f;
    public float frontNpcSpawnMax = 4f;

    // spawn a common npc at random intervals **TODO add random interval
    // spawn an uncommon npc at random intervals **TODO add random interval
    // public float spawnNpcFrontInterval = 6f;

    // create an array of random spawn points **TODO see if I can randomly generate interval based on given range -8 - 8
    public float[] spawnXPositions;
    // int index = Random.Range(0, spawnXPositions.Length);
    public float fixedYPosition = 5f;

    // create an array of random prefabs to spawn
    public GameObject[] prefabs;


    void Start()
    {
        StartCoroutine(DelaySpawn());
        // float frontNpcSpawnInterval = Random.Range(0f, 3f);    
        // Debug.Log("START frontNpcSpawnInterval: " + frontNpcSpawnInterval);
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitUntil(() => GameManagerScript.spawnObjects);
        StartCoroutine(SpawnPrefab());
    }

    // part of the coroutine to respawn a prefab at random intervals depending on tag
    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            frontNpcSpawnInterval = Random.Range(frontNpcSpawnMin, frontNpcSpawnMax);  
            Debug.Log("SPAWN frontNpcSpawnInterval: " + frontNpcSpawnInterval);
            // float test = 0.6f + levelManager.increaseSpawn;
            // Debug.Log("current npc spawn interval: " + test);
            // bool spawnNpcFront = Random.value < 2f;
            // // Debug.Log("current npc spawn interval: " + levelManager.increaseSpawn);
            // if (spawnNpcFront)
            // {
            //     int index = Random.Range(0, spawnXPositions.Length);
            //     Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);
            //     int prefabIndex = Random.Range(0, prefabs.Length);
            //     Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);
            // }

            // yield return new WaitForSeconds(globalVariables.commonNpcSpawnInterval);

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

    // if (other.CompareTag("commonNPC"))
    // {
    //     yield return new WaitForSeconds(spawnCommonNpcInterval);
    // }
    // if (other.CompareTag("npc-front"))
    // {
    //     yield return new WaitForSeconds(spawnNpcFrontInterval);
    // }

    // create a list of npc tags for different sprites to spawn, with their own random timings
    // private string GetRandomNpcTag()
    // {
    //     string[] npcTags = { "common", "uncommon" };
    //     int index = Random.Range(0, npcTags.Length);
    //     return npcTags[index];
    // }

}
