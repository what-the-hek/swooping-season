using UnityEngine;
using TMPro;
using System.Collections;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public LevelManagerScript levelManager;
    public EndScript endGame;
    public HealthBarScript healthBar;
    public TextMeshProUGUI totalScore;
    // public TextMeshProUGUI healthScore;
    public TextMeshProUGUI missedScore;
    private SpriteRenderer spriteRenderer;
    private Color red;

    // public bool collectedCommonNpc = false;
    // public bool collectedNpcFront = false;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // HEALTH SCORE
        if (globalVariables.healthScore > 0)
        {
            if (other.CompareTag("obstacle") || other.CompareTag("carRight") || other.CompareTag("carLeft") || other.CompareTag("obstacle-building"))
            {
                MinusHealth();
                StartCoroutine(PlayerBlink());
            }
            if (other.CompareTag("boost"))
            {
                AddHealth();
            }
            if (other.CompareTag("commonNPC"))
            {
                AddScore();
            }
            else if (other.CompareTag("npc-front") || other.CompareTag("npc-back"))
            {
                AddScore();
            }
        }

        // LEVEL UP
        // if (globalVariables.totalScore >= globalVariables.scoreMilestone)
        // {
        //     levelManager.LevelUp();
        // }

        // END GAME
        if (globalVariables.healthScore == 0)
        {
            endGame.EndGame();
        }

    }

    public void AddScore()
    {
        globalVariables.totalScore += 1;
        totalScore.text = $"{globalVariables.totalScore}";
        // globalVariables.totalScore += 2;
        // totalScore.text = $"score: {globalVariables.totalScore}";
        // collectedNpcFront = true;
        // Debug.Log("collected uncommon npc: " + collectedNpcFront);
    }

    public void MinusScore()
    {
        if (globalVariables.healthScore > 0)
        {
            globalVariables.missedScore -= 1;
            missedScore.text = $"{globalVariables.missedScore}";
            // Debug.Log("OUCH!! missed one");
        }
    }

    public void AddHealth()
    {
        if (globalVariables.healthScore < 5)
        {
            globalVariables.healthScore += 1;
            // healthScore.text = $"{globalVariables.healthScore}";
            healthBar.UpdateEggs();
        }
    }

    public void MinusHealth()
    {
        globalVariables.healthScore -= 1;
        // healthScore.text = $"health: {globalVariables.healthScore}";
        healthBar.UpdateEggs();
    }

    // player collides with a non-trigger collider
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger: " + collision.gameObject.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }

    IEnumerator PlayerBlink()
    {
        Color orange;
        ColorUtility.TryParseHtmlString( "#C1440E" , out orange);
        Color original = spriteRenderer.color;
        spriteRenderer.color = orange;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = original;
    }
}
