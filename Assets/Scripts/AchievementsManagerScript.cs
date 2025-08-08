using UnityEngine;
using System.Collections;
using TMPro;

public class AchievementsManagerScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public GameManagerScript gameManager;
    // public CollisionDetectionScript minusScore;
    // public DisplayTrophiesScript displayTrophies;
    public bool wasCollected = false;
    public int hitCount;
    public int totalBoostHits;
    public bool gotCat1 = false;
    public bool gotCat2 = false;
    public bool gotCat3 = false;
    // public GameObject trophy;
    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        hitCount = 0;
        totalBoostHits = 0;
    }

    public void UpdateTopScores()
    {
        // update top scores 
        if (globalVariables.finalScore > globalVariables.highScore)
        {
            globalVariables.highScore = globalVariables.finalScore;
            globalVariables.highLevel = globalVariables.currentLevel;
            globalVariables.highMissedScore = globalVariables.missedScore;
            globalVariables.highTotalScore = globalVariables.totalScore;
            globalVariables.highTargetHits = globalVariables.targetHits;
            globalVariables.highTime = globalVariables.lastTime;
        }

        if (globalVariables.finalScore < -10)
        {
            if (globalVariables.finalScore < globalVariables.lowestScore)
            {
                globalVariables.lowestScore = globalVariables.finalScore;
            }
        }
    }

    public void UpdateAchievements()
    {
        // all 3 cats *skin
        if (globalVariables.cat1Unlocked && globalVariables.cat2Unlocked && globalVariables.cat3Unlocked)
        {
            globalVariables.catSkinUnlocked = true;
        }
        // all 3 dogs *skin
        if (globalVariables.dog1Unlocked && globalVariables.dog2Unlocked && globalVariables.dog3Unlocked)
        {
            globalVariables.dogSkinUnlocked = true;
        }
        // all 3 cats and dogs on a single run *skin
        if (globalVariables.catSkinUnlocked && globalVariables.dogSkinUnlocked)
        {
            globalVariables.animalsSkinUnlocked = true;
        }

        // eat all boosts in 1 game
        // unlock allBoostsUnlocked in the boosts script

        // eat no boosts in 1 game
        // unlock noBoostsUnlocked in the boosts script

        // both boost trophies *skin
        if (globalVariables.allBoostsUnlocked && globalVariables.noBoostsUnlocked)
        {
            globalVariables.boostSkinUnlocked = true;
        }

        // no npc misses (after 1 minute)
        if (globalVariables.missedScore == 0 && globalVariables.lastTime >= 60)
        {
            globalVariables.noMissesUnlocked = true;
        }
        // negative score (under -50)
        if (globalVariables.missedScore <= -50)
        {
            globalVariables.allMissesUnlocked = true;
        }
        // more than 6 hits on 1 target
        if (globalVariables.highTargetHits >= 6)
        {
            globalVariables.targetHitsUnlocked = true;
        }
        // above npc trophy combo *skin
        if (globalVariables.noMissesUnlocked && globalVariables.allMissesUnlocked && globalVariables.targetHitsUnlocked)
        {
            globalVariables.npcSkinUnlocked = true;
        }

        // die before 27 seconds
        if (globalVariables.lastTime <= 27)
        {
            globalVariables.lowTimeUnlocked = true;
        }
        // survive past 10 minutes
        if (globalVariables.lastTime >= 600)
        {
            globalVariables.highTimeUnlocked = true;
        }
        // survival combo *skin
        if (globalVariables.lowTimeUnlocked && globalVariables.highTimeUnlocked)
        {
            globalVariables.timeSkinUnlocked = true;
        }
    }
}
