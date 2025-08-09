using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class MagpieSkinsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public Image[] magpieSkins;
    private Color[] originalColors;
    public string[] MagpieSkinList;

    public Button leftButton;
    public Button rightButton;

    public TextMeshProUGUI magpieSkinText;
    

    public int currentIndex = 0;
    private int indexLength;

    // check if skin unlocked
    // list of global variables for unlocked skins
    List<bool> unlockedSkinsList;
    Color grey;

    void Start()
    {
        Debug.Log("catSkinUnlocked SKINS = " + globalVariables.catSkinUnlocked);
		Debug.Log("dogSkinUnlocked SKINS = " + globalVariables.dogSkinUnlocked);

        originalColors = new Color[magpieSkins.Length];
        for (int index = 0; index < magpieSkins.Length; index++)
        {
            originalColors[index] = magpieSkins[index].color;
        }

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
            Color magpieColor = originalColors[magpieIndex];
            magpieSkins[magpieIndex].gameObject.SetActive(magpieIndex == currentIndex);
            if (!unlockedSkinsList[currentIndex])
            {
                ColorUtility.TryParseHtmlString("#7A7668", out grey);
                magpieSkins[magpieIndex].color = grey;
                globalVariables.magpieSkinsIndex = 0;
                Debug.Log("!!!! SKIN IS LOCKED !!!!! " + currentIndex);
            }
            else
            {
                globalVariables.magpieSkinsIndex = currentIndex;
                magpieSkins[magpieIndex].color = magpieColor;
                Debug.Log("!!!! SKIN IS UNLOCKED !!!!! " + currentIndex);
            }
        }
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < magpieSkins.Length - 1;
    }

    private void ShowCurrentSkinText()
    {
        if (currentIndex >= 0 && currentIndex < MagpieSkinList.Length)
        {
            if (!unlockedSkinsList[currentIndex])
            {
                magpieSkinText.text = "Locked";
            }
            else
            {
                magpieSkinText.text = MagpieSkinList[currentIndex];
            }
        }
    }

}
