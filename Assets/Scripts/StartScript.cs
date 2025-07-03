using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartScript : MonoBehaviour
{
   	public globalVariables globalVariables;
    public string sceneName = "";
    public Button playButton;
    public Button exitButton;
	public TextMeshProUGUI highScore;
	public TextMeshProUGUI highLevel;

	void Start()
	{
		Debug.Log("GAME START");
		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(TaskOnClickPlay);

		Button exitBtn = exitButton.GetComponent<Button>();
		exitBtn.onClick.AddListener(TaskOnClickExit);

		highScore.text = $"high score: {globalVariables.highScore}";
		highLevel.text = $"high level: {globalVariables.highLevel}";

		// RESET ALL MOVEMENT SPEEDS & MILESTONES
		
	}

	void TaskOnClickPlay(){
        SceneManager.LoadScene(sceneName);
		Debug.Log ("You have clicked Play!");
	}

    void TaskOnClickExit(){
        Application.Quit();
		Debug.Log ("You have clicked the Exit!");
	}

}