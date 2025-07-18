using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManagerScript : MonoBehaviour
{
    public string sceneName = "";
    private bool isPaused = false;
    public GameObject pauseBlob;
    public static bool spawnObjects = false;

    void Start()
    {
        StartCoroutine(EnableSpawningAfterDelay());
    }

    IEnumerator EnableSpawningAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        spawnObjects = true;
    }

    void Update()
    {
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
