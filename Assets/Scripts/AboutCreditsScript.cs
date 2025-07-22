using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutCreditsScript : MonoBehaviour
{
    public string startScene = "";
    public Button backButton;
    void Start()
    {
        Button backBtn = backButton.GetComponent<Button>();
		backBtn.onClick.AddListener(TaskOnClickBack);
    }

	void TaskOnClickBack()
	{
		SceneManager.LoadScene(startScene);
	}
}
