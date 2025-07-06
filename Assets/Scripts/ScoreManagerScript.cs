using UnityEngine;
using TMPro;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public LevelManagerScript levelManager;
    public EndScript endGame;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI healthScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (globalVariables.healthScore > 0)
        {
            // HEALTH SCORE
            if (other.CompareTag("obstacle") || other.CompareTag("carRight") || other.CompareTag("carLeft"))
            {
                globalVariables.healthScore -= 1;
                healthScore.text = $"health: {globalVariables.healthScore}";
            }
            if (other.CompareTag("boost"))
            {
                if (globalVariables.healthScore < 5)
                {
                    globalVariables.healthScore += 1;
                    healthScore.text = $"health: {globalVariables.healthScore}";
                }
            }

            // TOTAL SCORE
            if (other.CompareTag("commonNPC"))
            {
                globalVariables.totalScore += 1;
                totalScore.text = $"score: {globalVariables.totalScore}";
            }
            else if (other.CompareTag("uncommonNPC"))
            {
                globalVariables.totalScore += 2;
                totalScore.text = $"score: {globalVariables.totalScore}";
            }

            // LEVEL UP
            if (globalVariables.totalScore >= globalVariables.scoreMilestone)
            {
                levelManager.LevelUp();
            }
        }
        
        // END GAME
        if (globalVariables.healthScore == 0)
        {
            endGame.EndGame();
        }

    }

    // player collides with a non-trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger: " + collision.gameObject.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }

}
