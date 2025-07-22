using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private static MusicManagerScript backgroundTrack;

    void Awake()
    {
        if (backgroundTrack == null)
        {
            backgroundTrack = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

