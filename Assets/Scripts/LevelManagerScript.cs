using UnityEngine;
using TMPro;

public class LevelManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public SpawnNpcScript spawnNpc;
    public TextMeshProUGUI levelScore;
    // public float increaseSpawn = 0f;
    public void LevelUp()
    {
        // Debug.Log("total score: " + globalVariables.totalScore + "greater than milestone: " + globalVariables.scoreMilestone);
        if (spawnNpc.frontNpcSpawnMin > 1f)
        {
            spawnNpc.frontNpcSpawnMin -= 0.1f;
            spawnNpc.frontNpcSpawnMax -= 0.1f;
        }
        // Debug.Log("LEVEL UP: " + increaseSpawn);

        globalVariables.playerMovementSpeed += globalVariables.increasePlayerMovementSpeed;

        globalVariables.backgroundScrollSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonObstacleMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonBoostMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonNpcMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.npcFrontMovementSpeed += globalVariables.increaseScrollSpeed;

        globalVariables.carRightMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.carLeftMovementSpeed += globalVariables.increaseScrollSpeed;


        // if (globalVariables.commonNpcSpawnInterval > 1)
        // {
        //     // there is a bug with minus values where too many spawn, need to change this so that it spawns 2 prefabs instead of 1
        //     // rather than continuing to try and decrease the spawn interval
        //     globalVariables.commonNpcSpawnInterval -= globalVariables.descreaseSpawnInterval;
        //     globalVariables.npcFrontSpawnInterval -= globalVariables.descreaseSpawnInterval;
        //     globalVariables.commonObstacleSpawnInterval -= globalVariables.descreaseSpawnInterval;
        //     globalVariables.uncommonObstacleSpawnInterval -= globalVariables.descreaseSpawnInterval;
        //     // globalVariables.commonBoostSpawnInterval -= globalVariables.descreaseSpawnInterval;
        //     // globalVariables.uncommonBoostSpawnInterval -= globalVariables.descreaseSpawnInterval;
        // }

        // Debug.Log("background Scroll Speed: " + globalVariables.backgroundScrollSpeed);

        // Debug.Log("SPAWN INTERVAL LEVEL UP;" + globalVariables.commonNpcSpawnInterval);

        globalVariables.currentLevel++;
        // Debug.Log("current level: " + globalVariables.currentLevel);

        levelScore.text = $"{globalVariables.currentLevel}";

        globalVariables.scoreMilestone += globalVariables.increaseMilestone;
        // Debug.Log("next score milestone: " + globalVariables.scoreMilestone);
    }

}
