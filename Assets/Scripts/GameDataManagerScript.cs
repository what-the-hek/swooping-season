using UnityEngine;

public static class GameDataManager
{
    public static void SaveGameData()
    {
        // top scores
        PlayerPrefs.SetInt("HighScore", globalVariables.highScore);
        PlayerPrefs.SetInt("HighLevel", globalVariables.highLevel);
        PlayerPrefs.SetInt("HighMissedScore", globalVariables.highMissedScore);
        PlayerPrefs.SetInt("HighTotalScore", globalVariables.highTotalScore);
        PlayerPrefs.SetInt("HighTargetHits", globalVariables.highTargetHits);
        PlayerPrefs.SetInt("LowestScore", globalVariables.lowestScore);
        PlayerPrefs.SetFloat("HighTime", globalVariables.highTime);

        // last game scores
        PlayerPrefs.SetInt("LastFinalScore", globalVariables.lastFinalScore);
        PlayerPrefs.SetInt("LastScore", globalVariables.lastScore);
        PlayerPrefs.SetInt("LastMissed", globalVariables.lastMissed);
        PlayerPrefs.SetInt("LastLevel", globalVariables.lastLevel);
        PlayerPrefs.SetInt("LastTargetHits", globalVariables.lastTargetHits);
        PlayerPrefs.SetFloat("LastTime", globalVariables.lastTime);

        // achievements
        PlayerPrefs.SetInt("Cat1Unlocked", globalVariables.cat1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Cat2Unlocked", globalVariables.cat2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Cat3Unlocked", globalVariables.cat3Unlocked ? 1 : 0);

        PlayerPrefs.Save();
    }

    public static void LoadGameData()
    {
        // top scores
        globalVariables.highScore = PlayerPrefs.GetInt("HighScore", 0);
        globalVariables.highLevel = PlayerPrefs.GetInt("HighLevel", 0);
        globalVariables.highMissedScore = PlayerPrefs.GetInt("HighMissedScore", 0);
        globalVariables.highTotalScore = PlayerPrefs.GetInt("HighTotalScore", 0);
        globalVariables.highTargetHits = PlayerPrefs.GetInt("HighTargetHits", 0);
        globalVariables.lowestScore = PlayerPrefs.GetInt("LowestScore", 0);
        globalVariables.highTime = PlayerPrefs.GetFloat("HighTime", 0f);

        // last game scores
        globalVariables.lastFinalScore = PlayerPrefs.GetInt("LastFinalScore", 0);
        globalVariables.lastScore = PlayerPrefs.GetInt("LastScore", 0);
        globalVariables.lastMissed = PlayerPrefs.GetInt("LastMissed", 0);
        globalVariables.lastLevel = PlayerPrefs.GetInt("LastLevel", 0);
        globalVariables.lastTargetHits = PlayerPrefs.GetInt("LastTargetHits", 0);
        globalVariables.lastTime = PlayerPrefs.GetFloat("LastTime", 0f);

        // achievements
        globalVariables.cat1Unlocked = PlayerPrefs.GetInt("Cat1Unlocked", 0) == 1;
        globalVariables.cat2Unlocked = PlayerPrefs.GetInt("Cat2Unlocked", 0) == 1;
        globalVariables.cat3Unlocked = PlayerPrefs.GetInt("Cat3Unlocked", 0) == 1;
    }

    public static void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}