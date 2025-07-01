using UnityEngine;

public class globalVariables
{
    // scores
    public static int totalScore;
    public static int healthScore = 5;

    // track the number of objects currently on screen, for reducing the number of rare items
    public static int commonBoostAvailable;
    public static int uncommonBoostAvailable;

    // level tracking
    public static int currentLevel = 0;
    public static int[] scoreMilestones;

    // timing variables for increasing difficulty with level manager
    public static float backgroundScrollSpeed;
    // these movement speeds should always match the background speed
    public static float commonObjectMovementSpeed;
    public static float uncommonObjectMovementSpeed;
    public static float commonBoostMovementSpeed;
    public static float uncommonBoostMovementSpeed;
    // other movement speeds
    public static float commonNpcMovementSpeed;
    public static float uncommonNpcMovementSpeed;
    // spawn intervals
    public static float commonNpcSpawnInterval;
    public static float uncommonNpcSpawnInterval;
    public static float commonObjectSpawnInterval;
    public static float uncommonObjectSpawnInterval;
    public static float commonBoostSpawnInterval;
    public static float uncommonBoostSpawnInterval;



}

