using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class EndScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameManagerScript gameManager;
    public AchievementsManagerScript achievementsManager;
    public GameObject gameOverBlob;
    public Button continueButton;
    public TMP_InputField inputField;
    public string sceneName = "";
    public bool gameOver = false;

    public void EndGame()
    {
        // Debug.Assert(continueButton != null, "ContinueButton not assigned in Inspector!");
        gameOver = true;

        // final score
        globalVariables.finalScore = globalVariables.totalScore + globalVariables.missedScore;

        // update last game scores
        globalVariables.lastFinalScore = globalVariables.finalScore;
        globalVariables.lastScore = globalVariables.totalScore;
        globalVariables.lastMissed = globalVariables.missedScore;
        globalVariables.lastLevel = globalVariables.currentLevel;
        globalVariables.lastTargetHits = globalVariables.targetHits;
        globalVariables.lastTime = gameManager.timer;
        globalVariables.lastGameName = inputField.text;
        Debug.Log("GB last game name - end game:" + globalVariables.lastGameName);

        gameOverBlob.SetActive(true);

        // achievementsManager.UpdateAchievements();
        // Debug.Log("--- Updating achievements data ---");
        achievementsManager.UpdateTopScores();
        // Debug.Log("--- Updating top score data ---");
        // GameDataManager.SaveGameData();
        // Debug.Log("--- Saving game data ---");

        // StartCoroutine(returnToStart());
        Button continueBtn = continueButton.GetComponent<Button>();
        continueBtn.onClick.AddListener(TaskOnClickContinue);
    }

    void TaskOnClickContinue()
    {
        achievementsManager.UpdateAchievements();
        // achievementsManager.UpdateTopScores();
        gameOverBlob.SetActive(false);
        GameDataManager.SaveGameData();
        // Debug.Log("--- Saving game data ---");
        SceneManager.LoadScene(sceneName);
        Debug.Log("GB last game name - onclick:" + globalVariables.lastGameName);
    }
    // IEnumerator returnToStart()
    // {
    //     yield return new WaitForSeconds(globalVariables.returnToStartTimer);
    //     gameOverBlob.SetActive(false);
    //     SceneManager.LoadScene(sceneName);
    // }
}
