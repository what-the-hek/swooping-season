using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public void LevelUp()
    {
        Debug.Log("total score: " + globalVariables.totalScore + "greater than milestone: " + globalVariables.scoreMilestone);

        globalVariables.playerMovementSpeed += globalVariables.increasePlayerMovementSpeed;

        globalVariables.backgroundScrollSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonObstacleMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonBoostMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonNpcMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.uncommonNpcMovementSpeed += globalVariables.increaseScrollSpeed;

        globalVariables.commonNpcSpawnInterval += globalVariables.increaseSpawnSpeed;
        globalVariables.uncommonNpcSpawnInterval += globalVariables.increaseSpawnSpeed;
        globalVariables.commonObstacleSpawnInterval += globalVariables.increaseSpawnSpeed;
        globalVariables.uncommonObstacleSpawnInterval += globalVariables.increaseSpawnSpeed;
        // globalVariables.commonBoostSpawnInterval += globalVariables.increaseSpawnSpeed;
        // globalVariables.uncommonBoostSpawnInterval += globalVariables.increaseSpawnSpeed;

        // Debug.Log("background Scroll Speed: " + globalVariables.backgroundScrollSpeed);

        globalVariables.currentLevel++;
        Debug.Log("current level: " + globalVariables.currentLevel);

        globalVariables.scoreMilestone += globalVariables.increaseMilstone;
        Debug.Log("next score milestone: " + globalVariables.scoreMilestone);
    }

}
