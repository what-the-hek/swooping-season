using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class DisplayTrophiesScript : MonoBehaviour
{
    public Image[] catTrophies;
    public Image[] dogTrophies;
    public MoveSpecialTargetsScript targetsScript;

public void UpdateCats(string tag)
{
    switch (tag)
    {
        case "cat1":
            Debug.Log("!!!!!!!!!!!!! hit cat 1!");
            catTrophies[0].gameObject.SetActive(true);
            break;

        case "cat2":
            Debug.Log("!!!!!!!!!!!!! hit cat 2!");
            catTrophies[1].gameObject.SetActive(true);
            break;

        case "cat3":
        Debug.Log("!!!!!!!!!!!!! hit cat 3!");
            catTrophies[2].gameObject.SetActive(true);
            break;

        default:
            Debug.Log("!!!!!!!!!!!!! hit an unknown cat!" + tag);
            break;
    }
}

    public void UpdateDogs(string tag)
    {
        switch (tag)
        {
            case "dog1":
                Debug.Log("!!!!!!!!!!!!! hit dog 1!");
                dogTrophies[0].gameObject.SetActive(true);
                break;

            case "dog2":
                Debug.Log("!!!!!!!!!!!!! hit dog 2!");
                dogTrophies[1].gameObject.SetActive(true);
                break;

            case "dog3":
            Debug.Log("!!!!!!!!!!!!! hit dog 3!");
                dogTrophies[2].gameObject.SetActive(true);
                break;

            default:
                Debug.Log("!!!!!!!!!!!!! hit an unknown dog!" + tag);
                break;
        }
    }
}
