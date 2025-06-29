using System.Collections;
using UnityEngine;

public class SpawnNpcScript : MonoBehaviour
{

    // spawn a common npc at random intervals between x - y
    public float spawnCommonInterval = 4f;
    // spawn an uncommon npc at random intervals between x - y
    // public float spawnUncommonNpcInterval = 2f;

    // create an array of random spawn points
    // public float[] spawnXPositions = { -3f, 0f, 3f };
    // int index = Random.Range(0, spawnXPositions.Length);
    public float fixedYPosition = -5f;

    // create an array of random prefabs to spawn
    public GameObject[] prefabs;


    void Start()
    {
        // start a coroutine and spawn prefabs
        StartCoroutine(SpawnPrefab());
        Debug.Log("spawn start");

    }

    // part of the coroutine to respawn a prefab at random intervals depending on tag
    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            float[] spawnXPositions = new float[] { -3f, 0f, 3f };
            int index = Random.Range(0, spawnXPositions.Length);
            Debug.Log("spawn update: " + index);

            Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);

            // create the prefab at a random spawn point
            // GameObject newPrefab = Instantiate(prefabs[randomPrefabIndex], spawnPoints[randomSpawnIndex].position, Quaternion.identity);
            int prefabIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);

            // wait for the next spawn interval
            yield return new WaitForSeconds(spawnCommonInterval);
        }
    }

    // create a list of npc tags for different sprites to spawn
    // private string GetRandomNpcTag()
    // {
    //     string[] npcTags = { "common", "uncommon" };
    //     int index = Random.Range(0, npcTags.Length);
    //     return npcTags[index];
    // }

}
