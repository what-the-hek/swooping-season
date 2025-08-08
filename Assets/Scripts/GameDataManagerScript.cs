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

        // special target achievements
        PlayerPrefs.SetInt("Cat1Unlocked", globalVariables.cat1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Cat2Unlocked", globalVariables.cat2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Cat3Unlocked", globalVariables.cat3Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Dog1Unlocked", globalVariables.dog1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Dog2Unlocked", globalVariables.dog2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("Dog3Unlocked", globalVariables.dog3Unlocked ? 1 : 0);

        // other achievements
        PlayerPrefs.SetInt("AllBoostsUnlocked", globalVariables.allBoostsUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("NoBoostsUnlocked", globalVariables.noBoostsUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("NoMissesUnlocked", globalVariables.noMissesUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("AllMissesUnlocked", globalVariables.allMissesUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("TargetHitsUnlocked", globalVariables.targetHitsUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("LowTimeUnlocked", globalVariables.lowTimeUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("HighTimeUnlocked", globalVariables.highTimeUnlocked ? 1 : 0);

        // achievement skins
        PlayerPrefs.SetInt("CatSkinUnlocked", globalVariables.catSkinUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("DogSkinUnlocked", globalVariables.dogSkinUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("AnimalsSkinUnlocked", globalVariables.animalsSkinUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("BoostSkinUnlocked", globalVariables.boostSkinUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("NpcSkinUnlocked", globalVariables.npcSkinUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("TimeSkinUnlocked", globalVariables.timeSkinUnlocked ? 1 : 0);

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

        // special target achievements
        globalVariables.cat1Unlocked = PlayerPrefs.GetInt("Cat1Unlocked", 0) == 1;
        globalVariables.cat2Unlocked = PlayerPrefs.GetInt("Cat2Unlocked", 0) == 1;
        globalVariables.cat3Unlocked = PlayerPrefs.GetInt("Cat3Unlocked", 0) == 1;
        globalVariables.dog1Unlocked = PlayerPrefs.GetInt("Dog1Unlocked", 0) == 1;
        globalVariables.dog2Unlocked = PlayerPrefs.GetInt("Dog2Unlocked", 0) == 1;
        globalVariables.dog3Unlocked = PlayerPrefs.GetInt("Dog3Unlocked", 0) == 1;

        // other achievements
        globalVariables.allBoostsUnlocked = PlayerPrefs.GetInt("AllBoostsUnlocked", 0) == 1;
        globalVariables.noBoostsUnlocked = PlayerPrefs.GetInt("NoBoostsUnlocked", 0) == 1;
        globalVariables.noMissesUnlocked = PlayerPrefs.GetInt("NoMissesUnlocked", 0) == 1;
        globalVariables.allMissesUnlocked = PlayerPrefs.GetInt("AllMissesUnlocked", 0) == 1;
        globalVariables.targetHitsUnlocked = PlayerPrefs.GetInt("TargetHitsUnlocked", 0) == 1;
        globalVariables.lowTimeUnlocked = PlayerPrefs.GetInt("LowTimeUnlocked", 0) == 1;
        globalVariables.highTimeUnlocked = PlayerPrefs.GetInt("HighTimeUnlocked", 0) == 1;

        // achievement skins
        globalVariables.catSkinUnlocked = PlayerPrefs.GetInt("CatSkinUnlocked", 0) == 1;
        globalVariables.dogSkinUnlocked = PlayerPrefs.GetInt("DogSkinUnlocked", 0) == 1;
        globalVariables.animalsSkinUnlocked = PlayerPrefs.GetInt("AnimalsSkinUnlocked", 0) == 1;
        globalVariables.boostSkinUnlocked = PlayerPrefs.GetInt("BoostSkinUnlocked", 0) == 1;
        globalVariables.npcSkinUnlocked = PlayerPrefs.GetInt("NpcSkinUnlocked", 0) == 1;
        globalVariables.timeSkinUnlocked = PlayerPrefs.GetInt("TimeSkinUnlocked", 0) == 1;
    }

    public static void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}