using System.Collections;
using UnityEngine;

public class SpawnSpecialTargetsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public float specialTargetSpawnInterval;
    public float minSpawnInterval = 4f;
    public float maxSpawnInterval = 4.5f;
    public float[] spawnXPositions;
    public float fixedYPosition = 5f;
    public GameObject[] prefabs;


    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        // TODO change this spawn delay to 30 seconds, and/or only when the player has completed one game first
        yield return new WaitUntil(() => GameManagerScript.spawnObjects);
        StartCoroutine(SpawnCatsPrefab());
    }

    IEnumerator SpawnCatsPrefab()
    {
        while (true)
        {
            specialTargetSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            int index = Random.Range(0, spawnXPositions.Length);
            Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);
            int prefabIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(specialTargetSpawnInterval);
        }
    }

}
