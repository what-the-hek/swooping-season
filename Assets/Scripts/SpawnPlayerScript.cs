using UnityEngine;
using TMPro;


public class SpawnPlayerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public GameObject[] magpiePrefabs;
    private GameObject currentMagpie;
    public EndScript endScript;
    public HealthBarScript healthBarScript;

    public TextMeshProUGUI missedScoreUI;
    public TextMeshProUGUI totalScoreUI;

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedMagpieSkin", 0);
        currentMagpie = Instantiate(magpiePrefabs[selectedIndex], transform.position, Quaternion.identity);

        CollisionDetectionScript collisionScript = currentMagpie.GetComponent<CollisionDetectionScript>();
        collisionScript.Initialize(missedScoreUI, totalScoreUI, healthBarScript, endScript);
    }

}
