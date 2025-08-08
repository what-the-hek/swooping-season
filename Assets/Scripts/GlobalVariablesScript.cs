using UnityEngine;

public class globalVariables
{
    // top scores
    public static int highScore;
    public static int highLevel;
    public static int highMissedScore;
    public static int highTotalScore;
    public static int highTargetHits;
    public static int lowestScore;
    public static float highTime;

    // last game scores
    public static int lastFinalScore;
    public static int lastScore;
    public static int lastMissed;
    public static int lastLevel;
    public static int lastTargetHits;
    public static float lastTime;

    // scores
    public static int totalScore;
    public static int resetTotalScore = 0;
    public static int finalScore;
    public static int resetFinalScore = 0;
    public static int healthScore;
    public static int resetHealthScore = 5;
    public static int missedScore;
    public static int resetMissedScore = 0;
    public static int targetHits;
    public static int resetTargetHits = 0;
    public static int boostsSpawned;
    public static int resetboostsSpawned = 0;
    public static int boostsConsumed;
    public static int resetboostsConsumed = 0;

    // other
    public static int returnToStartTimer = 6;

    // TODO track the number of objects currently on screen, for reducing the number of rare items
    public static int commonBoostAvailable;
    public static int uncommonBoostAvailable;

    // level tracking
    public static int currentLevel;
    public static int resetCurrentLevel = 1;
    public static int scoreMilestone;
    public static int resetScoreMilestone = 10;

    public static int increaseMilestone = 10;
    public static float increaseScrollSpeed = 0.1f;
    public static float descreaseSpawnInterval = 0.1f;
    public static float increasePlayerMovementSpeed = 0.2f;


    // timing variables for increasing difficulty with level manager
    public static float backgroundScrollSpeed;
    public static float resetBackgroundScrollSpeed = 3f;

    // these movement speeds should always match the background speed - consider removing
    public static float commonObstacleMovementSpeed;
    public static float resetCommonObstacleMovementSpeed = 3f;

    public static float uncommonObstacleMovementSpeed;
    public static float resetUncommonObstacleMovementSpeed = 3f;

    public static float commonBoostMovementSpeed;
    public static float resetCommonBoostMovementSpeed = 3f;

    public static float uncommonBoostMovementSpeed;
    public static float resetUncommonBoostMovementSpeed = 3f;

    // obstacle movement speeds

    public static float carRightMovementSpeed;
    public static float resetCarRightMovementSpeed = 4.5f;
    public static float carLeftMovementSpeed;
    public static float resetCarLeftMovementSpeed = 3f;

    // other movement speeds
    public static float playerMovementSpeed;
    public static float resetPlayerMovementSpeed = 6f;
    public static float commonNpcMovementSpeed;
    public static float resetCommonNpcMovementSpeed = 2.5f;
    public static float npcFrontMovementSpeed;
    public static float resetNpcFrontMovementSpeed = 3.5f;

    // spawn intervals - TODO make these randomized intervals rather than set times
    public static float commonNpcSpawnInterval;
    public static float resetCommonNpcSpawnInterval = 5f;
    public static float npcFrontSpawnInterval;
    public static float resetNpcFrontSpawnInterval = 17f;
    public static float commonObstacleSpawnInterval;
    public static float resetCommonObstacleSpawnInterval = 5f;
    public static float uncommonObstacleSpawnInterval;
    public static float resetUncommonObstacleSpawnInterval = 17f;
    public static float commonBoostSpawnInterval;
    public static float resetCommonBoostSpawnInterval = 41f;
    public static float uncommonBoostSpawnInterval;
    public static float resetUncommonBoostSpawnInterval = 41f;

    // special target achievements
    public static bool cat1Unlocked = false;
    public static bool cat2Unlocked = false;
    public static bool cat3Unlocked = false;
    public static bool dog1Unlocked = false;
    public static bool dog2Unlocked = false;
    public static bool dog3Unlocked = false;

    // other achievements
    public static bool allBoostsUnlocked = false;
    public static bool noBoostsUnlocked = false;
    public static bool noMissesUnlocked = false;
    public static bool allMissesUnlocked = false;
    public static bool targetHitsUnlocked = false;
    public static bool lowTimeUnlocked = false;
    public static bool highTimeUnlocked = false;

    // achievement skins
    public static bool catSkinUnlocked = false;
    public static bool dogSkinUnlocked = false;
    public static bool animalsSkinUnlocked = false;
    public static bool boostSkinUnlocked = false;
    public static bool npcSkinUnlocked = false;
    public static bool timeSkinUnlocked = false;
}

