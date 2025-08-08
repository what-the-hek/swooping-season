using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public AchievementsManagerScript achievementsManager;
    
    public string sceneName = "";
    public GameObject gameOverBlob;

    public void EndGame()
    {
        globalVariables.playerMovementSpeed = 0f;

        // final score
        globalVariables.finalScore = globalVariables.totalScore + globalVariables.missedScore;

        // update last game scores
        globalVariables.lastFinalScore = globalVariables.finalScore;
        globalVariables.lastScore = globalVariables.totalScore;
        globalVariables.lastMissed = globalVariables.missedScore;
        globalVariables.lastLevel = globalVariables.currentLevel;
        globalVariables.lastTargetHits = globalVariables.targetHits;
        globalVariables.lastTime = gameManager.timer;

        gameOverBlob.SetActive(true);

        achievementsManager.UpdateAchievements();
        Debug.Log("--- Updating achievements data ---");
        achievementsManager.UpdateTopScores();
        Debug.Log("--- Updating top score data ---");
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
