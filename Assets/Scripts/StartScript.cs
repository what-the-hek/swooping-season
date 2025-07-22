using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartScript : MonoBehaviour
{
	public globalVariables globalVariables;
	public string playScene = "";
	public string scoresScene = "";
	public string aboutScene = "";
	public Button playButton;
	public Button exitButton;
	public Button scoresButton;
	public Button aboutButton;

	void Start()
	{
		Debug.Log("GAME START");

		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(TaskOnClickPlay);

		Button exitBtn = exitButton.GetComponent<Button>();
		exitBtn.onClick.AddListener(TaskOnClickExit);

		Button scoresBtn = scoresButton.GetComponent<Button>();
		scoresBtn.onClick.AddListener(TaskOnClickScores);

		Button aboutBtn = aboutButton.GetComponent<Button>();
		aboutBtn.onClick.AddListener(TaskOnClickAbout);

		// RESET ALL MOVEMENT SPEEDS & MILESTONES
		ResetVariables();
	}

	void TaskOnClickPlay()
	{
		SceneManager.LoadScene(playScene);
		Debug.Log("You have clicked Play!");
	}

	void TaskOnClickExit()
	{
		Application.Quit();
		Debug.Log("You have clicked the Exit!");
	}

	void TaskOnClickScores()
	{
		SceneManager.LoadScene(scoresScene);
		Debug.Log("You have clicked scores!");
	}

	void TaskOnClickAbout()
	{
		SceneManager.LoadScene(aboutScene);
		Debug.Log("You have clicked about!");
	}

	private void ResetVariables()
	{
		globalVariables.totalScore = globalVariables.resetTotalScore;
		globalVariables.healthScore = globalVariables.resetHealthScore;
		globalVariables.finalScore = globalVariables.resetFinalScore;
		globalVariables.missedScore = globalVariables.resetMissedScore;
		globalVariables.targetHits = globalVariables.resetTargetHits;

		globalVariables.currentLevel = globalVariables.resetCurrentLevel;
		globalVariables.scoreMilestone = globalVariables.resetScoreMilestone;

		globalVariables.backgroundScrollSpeed = globalVariables.resetBackgroundScrollSpeed;
		globalVariables.commonObstacleMovementSpeed = globalVariables.resetCommonObstacleMovementSpeed;
		globalVariables.uncommonObstacleMovementSpeed = globalVariables.resetUncommonObstacleMovementSpeed;
		globalVariables.commonBoostMovementSpeed = globalVariables.resetCommonBoostMovementSpeed;
		globalVariables.uncommonBoostMovementSpeed = globalVariables.resetUncommonBoostMovementSpeed;
		globalVariables.playerMovementSpeed = globalVariables.resetPlayerMovementSpeed;
		globalVariables.commonNpcMovementSpeed = globalVariables.resetCommonNpcMovementSpeed;
		globalVariables.npcFrontMovementSpeed = globalVariables.resetNpcFrontMovementSpeed;

		globalVariables.carRightMovementSpeed = globalVariables.resetCarRightMovementSpeed;
		globalVariables.carLeftMovementSpeed = globalVariables.resetCarLeftMovementSpeed;

		globalVariables.commonNpcSpawnInterval = globalVariables.resetCommonNpcSpawnInterval;
		globalVariables.npcFrontSpawnInterval = globalVariables.resetNpcFrontSpawnInterval;
		globalVariables.commonObstacleSpawnInterval = globalVariables.resetCommonObstacleSpawnInterval;
		globalVariables.uncommonObstacleSpawnInterval = globalVariables.resetUncommonObstacleSpawnInterval;
		globalVariables.commonBoostSpawnInterval = globalVariables.resetCommonBoostSpawnInterval;
		globalVariables.uncommonBoostSpawnInterval = globalVariables.resetUncommonBoostSpawnInterval;
	}
}