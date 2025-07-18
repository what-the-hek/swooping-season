using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string sceneName = "";
    private bool isPaused = false;
    public GameObject pauseBlob;
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

        // Optional: Show/hide pause UI
        // pausePanel.SetActive(isPaused);
    }

}
