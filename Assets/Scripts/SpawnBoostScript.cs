using System.Collections;
using UnityEngine;

public class SpawnBoostScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public float delaySpawn = 20f;
    public float[] spawnXPositions;
    public float fixedYPosition;

    // create an array of random prefabs to spawn
    public GameObject[] prefabs;
    public float boostSpawnInterval;
    public float minSpawnInterval = 7f;
    public float maxSpawnInterval = 7.5f;


    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitUntil(() => GameManagerScript.spawnObjects);
        StartCoroutine(SpawnPrefab());
    }

    // part of the coroutine to respawn a prefab at random intervals depending on tag
    IEnumerator SpawnPrefab()
    {
        // yield return new WaitForSeconds(delaySpawn); //why do I need this? does this stop the npc spawn bug?
        while (true)
        {
            if (globalVariables.healthScore < 5)
            {
                boostSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

                int index = Random.Range(0, spawnXPositions.Length);
                Vector3 spawnPosition = new Vector3(spawnXPositions[index], fixedYPosition, 0f);

                int prefabIndex = Random.Range(0, prefabs.Length);
                Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(boostSpawnInterval);
        }
    }
}

// StartCoroutine(AnimateScale(new Vector3(0.8f, 0.8f, 1f), 0.15f));


// IEnumerator AnimateScale(Vector3 targetScale, float duration)
// {
//     Vector3 originalScale = transform.localScale;
//     float time = 0f;

//     // Shrink
//     while (time < duration)
//     {
//         transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
//         time += Time.deltaTime;
//         yield return null;
//     }
//     transform.localScale = targetScale;

//     // Reset timer for grow
//     time = 0f;

//     // Grow back
//     while (time < duration)
//     {
//         transform.localScale = Vector3.Lerp(targetScale, originalScale, time / duration);
//         time += Time.deltaTime;
//         yield return null;
//     }
//     transform.localScale = originalScale;
// }
