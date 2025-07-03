using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // private bool milestoneReached = false;
    // public int nextMilestone;

    // void Start()
    // {
    //     nextMilestone = globalVariables.scoreMilestones[globalVariables.currentLevel];
    // }

    public void LevelUp()
    {
        if (globalVariables.totalScore >= globalVariables.scoreMilestone)
        {
            Debug.Log("total score: " + globalVariables.totalScore + "greater than milestone: " + globalVariables.scoreMilestone);

            globalVariables.backgroundScrollSpeed += globalVariables.increaseScrollSpeed;
            Debug.Log("background Scroll Speed: " + globalVariables.backgroundScrollSpeed);

            globalVariables.currentLevel++;
            Debug.Log("current level: " + globalVariables.currentLevel);

            globalVariables.scoreMilestone += globalVariables.increaseMilstone;
            Debug.Log("next score milestone: " + globalVariables.scoreMilestone);
        }
    }

}
