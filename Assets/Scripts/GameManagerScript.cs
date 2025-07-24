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
    public GameObject countDownBlob;
    public TextMeshProUGUI countDownText;
    public string sceneName = "";
    private bool isPaused = false;
    public static bool spawnObjects = false;
    public float timer = 0f;
    public float levelInterval = 5f;
    public float countDown;

    void Start()
    {
        spawnObjects = false;
        countDown = 4f;
        StartCoroutine(EnableSpawningAfterDelay());       
    }

    IEnumerator EnableSpawningAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        spawnObjects = true;
    }

    public void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
            int secondsOnly = Mathf.FloorToInt(countDown);
            countDownText.text = secondsOnly.ToString();
        }
        else
        {
            countDownBlob.SetActive(false);
        }
        if (globalVariables.healthScore > 0 && countDown <= 0)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (timer > levelInterval)
            {
                levelInterval += 5f;
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
