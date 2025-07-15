using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScorePageScript : MonoBehaviour
{
    public globalVariables globalVariables;
	public string startScene = "";
	public Button backButton;

    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;
    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;
    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;
    // public TextMeshProUGUI highScore;
    // public TextMeshProUGUI highLevel;

    void Start()
    {
        Button backBtn = backButton.GetComponent<Button>();
		backBtn.onClick.AddListener(TaskOnClickReturn);
        
        // highScore.text = $"high score: {globalVariables.highScore}";
        // highLevel.text = $"high level: {globalVariables.highLevel}";
    }

    void TaskOnClickReturn()
    {
        SceneManager.LoadScene(startScene);
    }
}
