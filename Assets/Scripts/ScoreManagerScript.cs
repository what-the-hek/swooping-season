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
    // private Color red;
    // private shrinkScale;

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
                StartCoroutine(PlayerBlinkOrange());
            }
            if (other.CompareTag("boost"))
            {
                AddHealth();
                StartCoroutine(PlayerBlinkBlue());
            }
            if (other.CompareTag("commonNPC"))
            {
                AddScore();
            }
            else if (other.CompareTag("npc-front") || other.CompareTag("npc-back") || other.CompareTag("cat1"))
            {
                AddScore();
                StartCoroutine(PlayerShrink(new Vector3(0.5f, 0.5f, 1f), 0.15f));
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

    IEnumerator PlayerBlinkOrange()
    {
        Color orange;
        ColorUtility.TryParseHtmlString("#C1440E", out orange);
        Color original = spriteRenderer.color;
        spriteRenderer.color = orange;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = original;
    }

    IEnumerator PlayerBlinkBlue()
    {
        Color blue;
        ColorUtility.TryParseHtmlString("#5F9EA0", out blue);
        Color original = spriteRenderer.color;
        spriteRenderer.color = blue;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = original;
    }

    // IEnumerator PlayerShrink()
    // {
    //     transform.localScale = new Vector3(0.6f, 0.6f, 1f);
    //     yield return new WaitForSeconds(0.3f);
    //     transform.localScale = new Vector3(0.7f, 0.7f, 1f);
    // }

    IEnumerator PlayerShrink(Vector3 shrinkScale, float duration)
    {

        Vector3 originalScale = transform.localScale;
        // Vector3 shrinkScale = (0.6f, 0.6f, 1f);
        float time = 0f;
        // float duration = 0.1f;


        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, shrinkScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = shrinkScale;
        time = 0f;
        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(shrinkScale, originalScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;

    }

    IEnumerator PlayerGrow()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(0.7f, 0.7f, 1f);
    }

}
