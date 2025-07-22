using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public LevelManagerScript levelManager;
    public GameObject pauseBlob;
    public TextMeshProUGUI timerText;
    public string sceneName = "";
    private bool isPaused = false;
    public static bool spawnObjects = false;
    public float timer = 0f;
    public float levelInterval;

    void Start()
    {
        StartCoroutine(EnableSpawningAfterDelay());
    }

    IEnumerator EnableSpawningAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        spawnObjects = true;
    }

    public void Update()
    {
        if (globalVariables.healthScore > 0)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (timer > levelInterval)
            {
                levelInterval += levelInterval;
                Debug.Log("level interval: " + levelInterval);
                levelManager.LevelUp();
            }

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Quit Game");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }
    }
    
    void TogglePause()
    {
        isPaused = !isPaused;
        pauseBlob.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

}
