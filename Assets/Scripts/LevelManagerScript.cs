using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public void LevelUp()
    {
        Debug.Log("total score: " + globalVariables.totalScore + "greater than milestone: " + globalVariables.scoreMilestone);

        globalVariables.backgroundScrollSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonObstacleMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonBoostMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.commonNpcMovementSpeed += globalVariables.increaseScrollSpeed;
        globalVariables.uncommonNpcMovementSpeed += globalVariables.increaseScrollSpeed;
        // Debug.Log("background Scroll Speed: " + globalVariables.backgroundScrollSpeed);

        globalVariables.currentLevel++;
        Debug.Log("current level: " + globalVariables.currentLevel);

        globalVariables.scoreMilestone += globalVariables.increaseMilstone;
        Debug.Log("next score milestone: " + globalVariables.scoreMilestone);
    }

}
