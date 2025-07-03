using UnityEngine;
using System.Collections;


public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;

    public void EndGame()
    {
        Debug.Log("YOU LOSE");
        Debug.Log("FINAL SCORE: " + globalVariables.totalScore);
        globalVariables.playerMovementSpeed = 0f;
    }
}
