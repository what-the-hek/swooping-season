using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    
    public string sceneName = "";
    public GameObject gameOverBlob;

    public void EndGame()
    {
        globalVariables.playerMovementSpeed = 0f;
        gameOverBlob.SetActive(true);

        // TODO change highScore global variable to a PlayerPrefs.int - use PlayerPrefs.Save()

        // final score
        globalVariables.finalScore = globalVariables.totalScore + globalVariables.missedScore;

        // update last game scores
        globalVariables.lastFinalScore = globalVariables.finalScore;
        globalVariables.lastScore = globalVariables.totalScore;
        globalVariables.lastMissed = globalVariables.missedScore;
        globalVariables.lastLevel = globalVariables.currentLevel;
        globalVariables.lastTargetHits = globalVariables.targetHits;
        globalVariables.lastTime = gameManager.timer;

        // update top scores 
        if (globalVariables.finalScore > globalVariables.highScore)
        {
            globalVariables.highScore = globalVariables.finalScore;
            globalVariables.highLevel = globalVariables.currentLevel;
            globalVariables.highMissedScore = globalVariables.missedScore;
            globalVariables.highTotalScore = globalVariables.totalScore;
            globalVariables.highTargetHits = globalVariables.targetHits;
            globalVariables.highTime = globalVariables.lastTime;
        }
        // if (globalVariables.currentLevel > globalVariables.highLevel)
        // {
        //     globalVariables.highLevel = globalVariables.currentLevel;
        // }
        // if (globalVariables.missedScore < globalVariables.highMissedScore)
        // {
        //     globalVariables.highMissedScore = globalVariables.missedScore;
        // }
        // if (globalVariables.totalScore > globalVariables.highTotalScore)
        // {
        //     globalVariables.highTotalScore = globalVariables.totalScore;
        // }
        // if (globalVariables.targetHits > globalVariables.highTargetHits)
        // {
        //     globalVariables.highTargetHits = globalVariables.targetHits;
        // }
        // if (globalVariables.lastTime > globalVariables.highTime)
        // {
        //     globalVariables.highTime = globalVariables.lastTime;
        // }
        if (globalVariables.finalScore < -10)
        {
            if (globalVariables.finalScore < globalVariables.lowestScore)
            {
                globalVariables.lowestScore = globalVariables.finalScore;
            }
        }

        GameDataManager.SaveGameData();
        Debug.Log("--- Saving game data ---");

        StartCoroutine(returnToStart());
    }

    IEnumerator returnToStart()
    {
        yield return new WaitForSeconds(globalVariables.returnToStartTimer);
        gameOverBlob.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}

// player prefs example
// if (totalScore > PlayerPrefs.GetInt("HighScore", 0))
// {
//     PlayerPrefs.SetInt("HighScore", totalScore);
//     PlayerPrefs.Save();
// }

// int highScore = PlayerPrefs.GetInt("HighScore", 0);
// highScoreText.text = "High Score: " + highScore;
