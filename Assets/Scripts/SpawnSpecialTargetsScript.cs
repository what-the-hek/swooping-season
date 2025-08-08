using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnSpecialTargetsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public float spawnDelay;
    public float[] spawnXPositions;
    public float fixedYPosition = 5f;

    [System.Serializable]
    public class SpecialTarget
    {
        public string targetName;
        public GameObject prefab;
        public float minSpawnInterval;
        public float maxSpawnInterval;
        public bool hasSpawned = false;
    }
    public List<SpecialTarget> specialTargets;

    void Start()
    {
        foreach (SpecialTarget target in specialTargets)
        {
            Debug.Log("target name: " + target.targetName);
            if (!target.hasSpawned)
            {
                Debug.Log("target has not spawned? : " + target.hasSpawned);
                spawnDelay = Random.Range(target.minSpawnInterval, target.maxSpawnInterval);
                StartCoroutine(SpawnCatsPrefab(target, spawnDelay));
            }  
        }
    }

    IEnumerator SpawnCatsPrefab(SpecialTarget target, float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Debug.Log("target is currently in play: " + target.targetName);
        int index = Random.Range(0, spawnXPositions.Length);
        Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);
        Instantiate(target.prefab, spawnPosition, Quaternion.identity);
        target.hasSpawned = true;
        Debug.Log("target has spawned? : " + target.hasSpawned);
        Debug.Log("_______________________________________________");
    }

}
