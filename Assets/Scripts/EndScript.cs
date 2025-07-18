using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public TextMeshProUGUI gameOver;
    public string sceneName = "";
    public GameObject gameOverBlob;

    public void EndGame()
    {
        // TODO change highScore global variable to a PlayerPrefs.int - use PlayerPrefs.Save()

        // final score
        globalVariables.finalScore = globalVariables.totalScore + globalVariables.missedScore;

        // update last game scores
        globalVariables.lastFinalScore = globalVariables.finalScore;
        globalVariables.lastScore = globalVariables.totalScore;
        globalVariables.lastMissed = globalVariables.missedScore;
        globalVariables.lastLevel = globalVariables.currentLevel;
        globalVariables.lastTargetHits = globalVariables.targetHits;

        // update top scores
        if (globalVariables.finalScore > globalVariables.highScore)
        {
            globalVariables.highScore = globalVariables.finalScore;
        }
        if (globalVariables.currentLevel > globalVariables.highLevel)
        {
            globalVariables.highLevel = globalVariables.currentLevel;
        }
        if (globalVariables.missedScore < globalVariables.highMissedScore)
        {
            globalVariables.highMissedScore = globalVariables.missedScore;
        }
        if (globalVariables.totalScore > globalVariables.highTotalScore)
        {
            globalVariables.highTotalScore = globalVariables.totalScore;
        }
        if (globalVariables.targetHits > globalVariables.highTargetHits)
        {
            globalVariables.highTargetHits = globalVariables.targetHits;
        }
        if (globalVariables.finalScore < -10)
        {
            if (globalVariables.finalScore < globalVariables.lowestScore)
            {
                globalVariables.lowestScore = globalVariables.finalScore;
            }
        }


        // Debug.Log("YOU LOSE");
        // Debug.Log("SPAWN INTERVAL END GAME " + globalVariables.commonNpcSpawnInterval);
        globalVariables.playerMovementSpeed = 0f;
        gameOverBlob.SetActive(true);
        // gameOver.text = $"game over";
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
