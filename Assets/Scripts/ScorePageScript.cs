using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScorePageScript : MonoBehaviour
{
    public globalVariables globalVariables;
	public string startScene = "";
	public Button backButton;

    public TextMeshProUGUI finalHScore;
    public TextMeshProUGUI levelHScore;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI totalScore;
    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;
    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;

    void Start()
    {
        Button backBtn = backButton.GetComponent<Button>();
        backBtn.onClick.AddListener(TaskOnClickReturn);

        finalHScore.text = $"{globalVariables.highScore}";
        levelHScore.text = $"{globalVariables.highLevel}";

        finalScore.text = $"{globalVariables.finalScore}";
        totalScore.text = $"{globalVariables.totalScore}";
        // highLevel.text = $"high level: {globalVariables.highLevel}";
    }

    void TaskOnClickReturn()
    {
        SceneManager.LoadScene(startScene);
    }
}
