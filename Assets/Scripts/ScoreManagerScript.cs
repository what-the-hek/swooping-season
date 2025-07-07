using UnityEngine;
using TMPro;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public LevelManagerScript levelManager;
    public EndScript endGame;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI healthScore;

    // public bool collectedCommonNpc = false;
    // public bool collectedUncommonNpc = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        // HEALTH SCORE
        if (globalVariables.healthScore > 0)
        {
            if (other.CompareTag("obstacle") || other.CompareTag("carRight") || other.CompareTag("carLeft"))
            {
                MinusHealth();
            }
            if (other.CompareTag("boost"))
            {
                AddHealth();
            }
        }

        // TOTAL SCORE
        if (other.CompareTag("commonNPC"))
        {
            // collectedCommonNpc = true;
            // Debug.Log("collected common npc: " + collectedCommonNpc);
            AddScore();
        }
        else if (other.CompareTag("uncommonNPC"))
        {
            // collectedUncommonNpc = true;
            // Debug.Log("collected uncommon npc: " + collectedUncommonNpc);
            AddScore();
        }

        // LEVEL UP
        if (globalVariables.totalScore >= globalVariables.scoreMilestone)
        {
            levelManager.LevelUp();
        }

        // END GAME
        if (globalVariables.healthScore == 0)
        {
            endGame.EndGame();
        }

    }

    public void AddScore()
    {
        globalVariables.totalScore += 1;
        totalScore.text = $"score: {globalVariables.totalScore}";
        // globalVariables.totalScore += 2;
        // totalScore.text = $"score: {globalVariables.totalScore}";
        // collectedUncommonNpc = true;
        // Debug.Log("collected uncommon npc: " + collectedUncommonNpc);
    }

    public void MinusScore()
    {
        globalVariables.totalScore -= 1;
        totalScore.text = $"score: {globalVariables.totalScore}";
        Debug.Log("OUCH!! missed one");
    }

    public void AddHealth()
    {
        if (globalVariables.healthScore < 5)
        {
            globalVariables.healthScore += 1;
            healthScore.text = $"health: {globalVariables.healthScore}";
        }
    }

    public void MinusHealth()
    {
        globalVariables.healthScore -= 1;
        healthScore.text = $"health: {globalVariables.healthScore}";
    }

    // player collides with a non-trigger collider
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger: " + collision.gameObject.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }
}
