using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class DisplayTrophiesScript : MonoBehaviour
{
    // public Image[] catTrophies;
    // public Image[] dogTrophies;
    public MoveSpecialTargetsScript targetsScript;

    public void UpdateCats(string tag)
    {
        if (tag == "cat1")
        {
            Debug.Log("!!!!!!!!!!!!! hit cat 1!");
        }
        else if (tag == "cat2")
        {
            Debug.Log("!!!!!!!!!!!!! hit cat 2!");
        }
        else if (tag == "cat3")
        {
            Debug.Log("!!!!!!!!!!!!! hit cat 3!");
        }
        else
        Debug.Log("!!!!!!!!!!!!! hit an unknown cat!");
    }

    public void UpdateDogs(string tag)
    {
        if (tag == "dog1")
        {
            Debug.Log("!!!!!!!!!!!!! hit dog 1!");
        }
        else if (tag == "dog2")
        {
            Debug.Log("!!!!!!!!!!!!! hit dog 2!");
        }
        else if (tag == "dog3")
        {
            Debug.Log("!!!!!!!!!!!!! hit dog 3!");
        }
        else
        Debug.Log("!!!!!!!!!!!!! hit an unknown dog!");
    }
}
