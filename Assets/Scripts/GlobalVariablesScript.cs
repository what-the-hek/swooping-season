using UnityEngine;

public class globalVariables
{
    // scores
    public static int totalScore;
    public static int resetTotalScore = 0;
    public static int finalScore;
    public static int resetFinalScore = 0;
    public static int healthScore;
    public static int resetHealthScore = 5;
    public static int missedScore;
    public static int resetMissedScore = 0;
    public static int highScore;
    public static int highLevel;
    public static int returnToStartTimer = 6;

    // track the number of objects currently on screen, for reducing the number of rare items
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
    public static float resetBackgroundScrollSpeed = 2f;

    // these movement speeds should always match the background speed - consider removing
    public static float commonObstacleMovementSpeed;
    public static float resetCommonObstacleMovementSpeed = 2f;

    public static float uncommonObstacleMovementSpeed;
    public static float resetUncommonObstacleMovementSpeed = 2f;

    public static float commonBoostMovementSpeed;
    public static float resetCommonBoostMovementSpeed = 2f;

    public static float uncommonBoostMovementSpeed;
    public static float resetUncommonBoostMovementSpeed = 2f;

    // obstacle movement speeds

    public static float carRightMovementSpeed;
    public static float resetCarRightMovementSpeed = 3.5f;
    public static float carLeftMovementSpeed;
    public static float resetCarLeftMovementSpeed = 2f;

    // other movement speeds
    public static float playerMovementSpeed;
    public static float resetPlayerMovementSpeed = 4f;
    public static float commonNpcMovementSpeed;
    public static float resetCommonNpcMovementSpeed = 1.5f;
    public static float uncommonNpcMovementSpeed;
    public static float resetUncommonNpcMovementSpeed = 2.5f;

    // spawn intervals - TODO make these randomized intervals rather than set times
    public static float commonNpcSpawnInterval;
    public static float resetCommonNpcSpawnInterval = 4f;
    public static float uncommonNpcSpawnInterval;
    public static float resetUncommonNpcSpawnInterval = 16f;
    public static float commonObstacleSpawnInterval;
    public static float resetCommonObstacleSpawnInterval = 4f;
    public static float uncommonObstacleSpawnInterval;
    public static float resetUncommonObstacleSpawnInterval = 16f;
    public static float commonBoostSpawnInterval;
    public static float resetCommonBoostSpawnInterval = 40f;
    public static float uncommonBoostSpawnInterval;
    public static float resetUncommonBoostSpawnInterval = 40f;
}

