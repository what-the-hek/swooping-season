using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
// using System.Collections;

public class ScorePageScript : MonoBehaviour
{
    public globalVariables globalVariables;
	public string startScene = "";
    public string[] funFacts;
	public Button backButton;

    public TextMeshProUGUI magpieFacts;

    // top scores
    public TextMeshProUGUI finalHScore;
    public TextMeshProUGUI levelHScore;
    public TextMeshProUGUI missedHScore;
    public TextMeshProUGUI totalHScore;
    public TextMeshProUGUI targetHitsHScore;
    public TextMeshProUGUI lowestHScore;

    // last game
    public TextMeshProUGUI lastFinalScore;
    public TextMeshProUGUI lastTotalScore;
    public TextMeshProUGUI lastMissedScore;
    public TextMeshProUGUI lastLevelScore;
    public TextMeshProUGUI lastTargetHitsScore;


    void Start()
    {
        Button backBtn = backButton.GetComponent<Button>();
        backBtn.onClick.AddListener(TaskOnClickReturn);

        // top scores
        finalHScore.text = $"{globalVariables.highScore}";
        levelHScore.text = $"{globalVariables.highLevel}";
        missedHScore.text = $"{globalVariables.highMissedScore}";
        totalHScore.text = $"{globalVariables.highTotalScore}";
        targetHitsHScore.text = $"{globalVariables.highTargetHits}";
        lowestHScore.text = $"{globalVariables.lowestScore}";

        // last game scores
        lastFinalScore.text = $"{globalVariables.lastFinalScore}";
        lastTotalScore.text = $"{globalVariables.lastScore}";
        lastMissedScore.text = $"{globalVariables.lastMissed}";
        lastLevelScore.text = $"{globalVariables.lastLevel}";
        lastTargetHitsScore.text = $"{globalVariables.lastTargetHits}";

        // random magpie facts
        int randomFact = Random.Range(0, funFacts.Length);
        magpieFacts.text = funFacts[randomFact];
    }

    void TaskOnClickReturn()
    {
        SceneManager.LoadScene(startScene);
    }
}
