using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ScorePageScript : MonoBehaviour
{
    public globalVariables globalVariables;
	public string startScene = "";
	public Button backButton;
    List<string> factsList;
    public TextMeshProUGUI magpieFacts;

    // top scores
    public TextMeshProUGUI finalHScore;
    public TextMeshProUGUI levelHScore;
    public TextMeshProUGUI missedHScore;
    public TextMeshProUGUI totalHScore;
    public TextMeshProUGUI targetHitsHScore;
    public TextMeshProUGUI lowestHScore;

    // last game
    public TextMeshProUGUI lastFinalScore;
    public TextMeshProUGUI lastTotalScore;
    public TextMeshProUGUI lastMissedScore;
    public TextMeshProUGUI lastLevelScore;
    public TextMeshProUGUI lastTargetHitsScore;


    void Start()
    {
        int hMinutes = Mathf.FloorToInt(globalVariables.highTime / 60f);
        int hSeconds = Mathf.FloorToInt(globalVariables.highTime % 60f);

        int lMinutes = Mathf.FloorToInt(globalVariables.lastTime / 60f);
        int lSeconds = Mathf.FloorToInt(globalVariables.lastTime % 60f);

        Button backBtn = backButton.GetComponent<Button>();
        backBtn.onClick.AddListener(TaskOnClickReturn);

        // top scores
        finalHScore.text = $"{globalVariables.highScore}";
        // levelHScore.text = $"{globalVariables.highLevel}";
        levelHScore.text = string.Format("{0:00}:{1:00}", hMinutes, hSeconds);
        missedHScore.text = $"{globalVariables.highMissedScore}";
        totalHScore.text = $"{globalVariables.highTotalScore}";
        targetHitsHScore.text = $"{globalVariables.highTargetHits}";
        lowestHScore.text = $"{globalVariables.lowestScore}";

        // last game scores
        lastFinalScore.text = $"{globalVariables.lastFinalScore}";
        lastTotalScore.text = $"{globalVariables.lastScore}";
        lastMissedScore.text = $"{globalVariables.lastMissed}";
        // lastLevelScore.text = $"{globalVariables.lastLevel}";
        lastLevelScore.text = string.Format("{0:00}:{1:00}", lMinutes, lSeconds);
        lastTargetHitsScore.text = $"{globalVariables.lastTargetHits}";

        // achievements
        Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Debug.Log("cat1Unlocked? " + globalVariables.cat1Unlocked);
        Debug.Log("cat2Unlocked? " + globalVariables.cat2Unlocked);
        Debug.Log("cat3Unlocked? " + globalVariables.cat3Unlocked);
        Debug.Log("dog1Unlocked? " + globalVariables.dog1Unlocked);
        Debug.Log("dog2Unlocked? " + globalVariables.dog2Unlocked);
        Debug.Log("dog3Unlocked? " + globalVariables.dog3Unlocked);
        Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        // random magpie facts
        factsList = new List<string>();
        factsList.Add("The Noongar name for magpie is Koorlbardi, also spelled Kulbardi, Koolbardi or Kooldjak. The Whadjuck Noongar people are from the Perth area of Western Australia.");
        factsList.Add("There are 9 different subspecies of magpies across Australia. Their plumage varies across these subspecies, including the amount of white feathering on their back.");
        factsList.Add("Australian magpies are known for their aggressive swooping during breeding season, however only about 8 to 10 percent of magpies swoop people.");
        factsList.Add("It is typically the male Australian magpie that defends the nest and swoops during breeding season, which peaks between August and November.");
        factsList.Add("Female Australian magpies lay between 3 to 5 eggs each season. The eggs are blue or green with brown blotches and take around 20 days to hatch.");
        factsList.Add("Australian magpies lifespan is 25-30 years and they can hold their territory for more than 10 years.");
        factsList.Add("Magpies usually mate for life, however if the male dies the female will find a new mate and he will continue to protect the young even if they are not biologically related.");
        factsList.Add("Australian magpies live in groups of up to 24 birds, called a 'tiding' or 'tribe'.");
        factsList.Add("Magpies can hear worms and other insects burrowing underground! They tilt their head to listen and then strike the ground to catch their prey.");
        factsList.Add("Magpies prefer to forage in open areas next to patches of trees, including grasslands and parks.");
        factsList.Add("Bird baths are a wonderful way to help our wildlife in summer. Baths and saucers placed on the ground in a spacious area can be more appealing to magpies.");
        factsList.Add("Magpies produce a range of flute-like songs, often referred to as a chortle, warbling, or carolling. Their pitch can vary up to 4 octaves.");
        factsList.Add("The closest relatives to Australian magpies include the butcherbird and currawong, they are all part of the Cracticidae family of birds.");
        factsList.Add("Young magpies are forced by their parents to leave their territory within 2 years. They join other young magpies as a group to seek out new territories.");

        int randomFactIndex = Random.Range(0, factsList.Count);
        magpieFacts.text = factsList[randomFactIndex];
    }

    void TaskOnClickReturn()
    {
        SceneManager.LoadScene(startScene);
    }
    
}
