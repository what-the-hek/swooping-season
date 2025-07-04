using System.Collections;
using UnityEngine;

public class SpawnBoostScript : MonoBehaviour
{
    public globalVariables globalVariables;

    public float delaySpawn = 30f;
    public float[] spawnXPositions;
    public float fixedYPosition;

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
        yield return new WaitForSeconds(delaySpawn);
        while (true)
        {
            int index = Random.Range(0, spawnXPositions.Length);
            Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);

            int prefabIndex = Random.Range(0, prefabs.Length);         
            Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(globalVariables.commonBoostSpawnInterval);
        }
    }
}
