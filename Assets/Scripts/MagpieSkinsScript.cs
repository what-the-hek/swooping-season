using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class MagpieSkinsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public Image[] magpieSkins;

    public Button leftButton;
    public Button rightButton;

    public TextMeshProUGUI magpieSkinText;
    public string[] MagpieSkinList;

    public int currentIndex = 0;
    private int indexLength;

    // check if skin unlocked
    // list of global variables for unlocked skins
    List<bool> unlockedSkinsList;

    void Start()
    {
        Debug.Log("catSkinUnlocked SKINS = " + globalVariables.catSkinUnlocked);
		Debug.Log("dogSkinUnlocked SKINS = " + globalVariables.dogSkinUnlocked);
        
        unlockedSkinsList = new List<bool>();
        unlockedSkinsList.Add(true);
        unlockedSkinsList.Add(globalVariables.catSkinUnlocked);
        unlockedSkinsList.Add(globalVariables.dogSkinUnlocked);
        unlockedSkinsList.Add(globalVariables.animalsSkinUnlocked);
        unlockedSkinsList.Add(globalVariables.boostSkinUnlocked);
        unlockedSkinsList.Add(globalVariables.npcSkinUnlocked);
        unlockedSkinsList.Add(globalVariables.timeSkinUnlocked);

        Button leftArrowBtn = leftButton.GetComponent<Button>();
        leftArrowBtn.onClick.AddListener(TaskOnClickLeft);

        Button rightArrowBtn = rightButton.GetComponent<Button>();
        rightArrowBtn.onClick.AddListener(TaskOnClickRight);

        indexLength = magpieSkins.Length;
        leftButton.interactable = false;
        ShowCurrentSkin();
        ShowCurrentSkinText();
    }

    public void TaskOnClickLeft()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            // Debug.Log("LEFT INDEX = " + currentIndex);
            ShowCurrentSkin();
            ShowCurrentSkinText();
        }
    }

    public void TaskOnClickRight()
    {
        if (currentIndex < indexLength - 1)
        {
            currentIndex++;
            // Debug.Log("RIGHT INDEX = " + currentIndex);
            ShowCurrentSkin();
            ShowCurrentSkinText();
        }
    }

    private void ShowCurrentSkin()
    {
        for (int magpieIndex = 0; magpieIndex < magpieSkins.Length; magpieIndex++)
        {
            magpieSkins[magpieIndex].gameObject.SetActive(magpieIndex == currentIndex);
            // create unlocked skins index to check if unlocked and match to magpie index
            if (!unlockedSkinsList[currentIndex])
            {
                globalVariables.magpieSkinsIndex = 0;
                Debug.Log("!!!! SKIN IS LOCKED !!!!! " + currentIndex);
            }
            else
            {
                globalVariables.magpieSkinsIndex = currentIndex;
                Debug.Log("!!!! SKIN IS UNLOCKED !!!!! " + currentIndex);
            }
            // for (int unlockedSkinsIndex = 0; unlockedSkinsIndex < unlockedSkinsList.Count; unlockedSkinsIndex++)
            // {
            //     if (unlockedSkinsList[unlockedSkinsIndex] == false)
            //     {
            //         globalVariables.magpieSkinsIndex = 0;
            //         Debug.Log("!!!! SKIN IS LOCKED !!!!! " + unlockedSkinsList[unlockedSkinsIndex]);
            //     }
            //     else
            //     {
            //         globalVariables.magpieSkinsIndex = currentIndex;
            //         Debug.Log("!!!! SKIN IS UNLOCKED !!!!! " + globalVariables.magpieSkinsIndex);
            //     }
            // }
        }

        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < magpieSkins.Length - 1;

    }

    private void ShowCurrentSkinText()
    {
        if (currentIndex >= 0 && currentIndex < MagpieSkinList.Length)
        {
            magpieSkinText.text = MagpieSkinList[currentIndex];
        }
    }

}
