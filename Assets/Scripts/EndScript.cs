using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;



public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI finalScore;

    public string sceneName = "";

    public void EndGame()
    {
        // TODO change highScore global variable to a PlayerPrefs.int - use PlayerPrefs.Save()
        globalVariables.finalScore = globalVariables.totalScore + globalVariables.missedScore;

        if (globalVariables.finalScore > globalVariables.highScore)
        {
            globalVariables.highScore = globalVariables.finalScore;
        }
        if (globalVariables.currentLevel > globalVariables.highLevel)
        {
            globalVariables.highLevel = globalVariables.currentLevel;
        }
        // Debug.Log("YOU LOSE");
        // Debug.Log("SPAWN INTERVAL END GAME " + globalVariables.commonNpcSpawnInterval);
        globalVariables.playerMovementSpeed = 0f;
        gameOver.text = $"game over";
        finalScore.text = $"total: {globalVariables.totalScore} \nmissed: {globalVariables.missedScore} \nfinal score: {globalVariables.finalScore}";
        StartCoroutine(returnToStart());
    }

    IEnumerator returnToStart()
    {
        yield return new WaitForSeconds(globalVariables.returnToStartTimer);
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
