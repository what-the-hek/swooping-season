using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public int nextMilestone;

    // void Start()
    // {
    //     nextMilestone = globalVariables.scoreMilestones[globalVariables.currentLevel];
    // }

    public void LevelUp()
    {
        if (globalVariables.totalScore >= 10)
        {
            Debug.Log("total score greater than 10: " + globalVariables.totalScore);
            globalVariables.backgroundScrollSpeed += 1f;
            Debug.Log("background Scroll Speed: " + globalVariables.backgroundScrollSpeed);
            globalVariables.currentLevel++;
            Debug.Log("current level: " + globalVariables.currentLevel);
        }
    }

}
