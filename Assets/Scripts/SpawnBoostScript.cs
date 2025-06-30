using System.Collections;
using UnityEngine;

public class SpawnBoostScript : MonoBehaviour
{

    public float spawnCommonBoostInterval = 10f;
    public float[] spawnXPositions;
    public float fixedYPosition = 5f;

    // create an array of random prefabs to spawn
    public GameObject[] prefabs;


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
            // create the prefab at a random spawn point
            int index = Random.Range(0, spawnXPositions.Length);
            Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);

            // select a random prefab from prefab index range
            int prefabIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);

            // wait for the next spawn interval
            yield return new WaitForSeconds(spawnCommonBoostInterval);
        }
    }
}
