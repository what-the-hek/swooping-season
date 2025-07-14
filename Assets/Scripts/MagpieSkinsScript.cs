using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class MagpieSkinsScript : MonoBehaviour
{
    public Image[] magpieSkins;

    public Button leftButton;
    public Button rightButton;

    public TextMeshProUGUI magpieSkinText;
    public string[] MagpieSkinList;

    private int currentIndex = 0;
    private int indexLength;

    void Start()
    {
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
            Debug.Log("LEFT INDEX = " + currentIndex);
            ShowCurrentSkin();
            ShowCurrentSkinText();
        }
    }

    public void TaskOnClickRight()
    {
        if (currentIndex < indexLength - 1)
        {
            currentIndex++;
            Debug.Log("RIGHT INDEX = " + currentIndex);
            ShowCurrentSkin();
            ShowCurrentSkinText();
        }
    }

    private void ShowCurrentSkin()
    {
        for (int magpieIndex = 0; magpieIndex < magpieSkins.Length; magpieIndex++)
        {
            magpieSkins[magpieIndex].gameObject.SetActive(magpieIndex == currentIndex);
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
