using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string sceneName = "";

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene(sceneName);
                Debug.Log("Quit Game");
            }
    }
}
