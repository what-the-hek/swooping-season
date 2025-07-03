using UnityEngine;

public class globalVariables
{
    // scores
    public static int totalScore;
    public static int healthScore = 5;
    public static int highScore;
    public static int highLevel;
    public static int returnToStartTimer = 6;

    // track the number of objects currently on screen, for reducing the number of rare items
    public static int commonBoostAvailable;
    public static int uncommonBoostAvailable;

    // level tracking
    public static int currentLevel = 0;
    public static int scoreMilestone = 10;
    public static int increaseMilstone = 10;

    public static float increaseScrollSpeed = 1f;

    // timing variables for increasing difficulty with level manager
    public static float backgroundScrollSpeed = 1f;
    // these movement speeds should always match the background speed
    public static float commonObstacleMovementSpeed = 1f;
    public static float uncommonObstacleMovementSpeed = 1f;
    public static float commonBoostMovementSpeed = 1f;
    public static float uncommonBoostMovementSpeed = 1f;
    // other movement speeds
    public static float playerMovementSpeed = 3f;
    public static float commonNpcMovementSpeed = 0.5f;
    public static float uncommonNpcMovementSpeed = 1.5f;
    // spawn intervals
    public static float commonNpcSpawnInterval;
    public static float uncommonNpcSpawnInterval;
    public static float commonObjectSpawnInterval;
    public static float uncommonObjectSpawnInterval;
    public static float commonBoostSpawnInterval;
    public static float uncommonBoostSpawnInterval;



}

