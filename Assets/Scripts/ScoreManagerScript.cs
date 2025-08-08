using UnityEngine;
using TMPro;
using System.Collections;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public EndScript endGame;
    public HealthBarScript healthBar;

    public TextMeshProUGUI missedScore;
    public TextMeshProUGUI totalScore;

    private SpriteRenderer spriteRenderer;

    private bool onCooldown = false;

    private Coroutine blinkCoroutine;
    private Coroutine scaleCoroutine;
    private Color orange;
    private Color blue;

    public void Initialize(TextMeshProUGUI missedScoreUI, TextMeshProUGUI totalScoreUI, HealthBarScript healthBarScript, EndScript endScript)
    {
        missedScore = missedScoreUI;
        totalScore = totalScoreUI;
        healthBar = healthBarScript;
        endGame = endScript;
    }

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // HEALTH SCORE
        if (globalVariables.healthScore > 0)
        {
            if (onCooldown == false)
            {
                if (other.CompareTag("obstacle") || other.CompareTag("carRight") || other.CompareTag("carLeft") || other.CompareTag("obstacle-building"))
                {
                    MinusHealth();
                    // StartCoroutine(PlayerBlinkOrange());
                    ColorUtility.TryParseHtmlString("#C1440E", out orange);
                    // TODO change TriggerBlink back to coroutine
                    TriggerBlink(orange, 0.1f);
                    StartCoroutine(PlayerImmunity());
                }
            }
            if (other.CompareTag("boost"))
            {
                AddHealth();
                ColorUtility.TryParseHtmlString("#5F9EA0", out blue);
                // TODO change TriggerBlink back to coroutine, but add a cooldown if statement so it doesn't interrupt existing coroutine
                // TriggerBlink(blue, 0.1f);
            }
            if (other.CompareTag("commonNPC"))
            {
                AddScore();
            }
            else if (other.CompareTag("npc-front") || other.CompareTag("npc-back") || other.CompareTag("cat1"))
            {
                AddScore();
                // StartCoroutine(PlayerShrink(new Vector3(0.5f, 0.5f, 1f), 0.15f));
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

    // public void TriggerBlink(Color newColor, float duration)
    // {
    //     if (blinkCoroutine == null)
    //     {
    //         blinkCoroutine = StartCoroutine(PlayerBlink(newColor, duration));
    //         Debug.Log("blink coroutine is not null");
    //     }
    //     StopCoroutine(blinkCoroutine);
    //     Debug.Log("coroutine already going!!!");

    //     // else if (blinkCoroutine != null)
    //     // {
    //     //     Debug.Log("coroutine already going!!!");
    //     // }
    //     // Debug.Log("start blink coroutine");
    //     // blinkCoroutine = StartCoroutine(PlayerBlink(newColor, duration));
    // }

    public void TriggerBlink(Color newColor, float duration)
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            // Debug.Log("blink coroutine is not null");
        }
        // Debug.Log("start blink coroutine");
        blinkCoroutine = StartCoroutine(PlayerBlink(newColor, duration));
    }

    IEnumerator PlayerBlink(Color newColor, float duration)
    {
        // Debug.Log("Player blink!!!!!!!!!!!");
        Color original = spriteRenderer.color;
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = original;
    }

    // public void TriggerScale(Vector3 newSize, float duration)
    // {
    //     if (scaleCoroutine != null)
    //         StopCoroutine(scaleCoroutine);
    //     scaleCoroutine = StartCoroutine(PlayerScale(newSize, duration));
    // }

    IEnumerator PlayerImmunity()
    {
        onCooldown = true;
        // Debug.Log("on cool down true? " + onCooldown);
        yield return new WaitForSeconds(0.3f);
        onCooldown = false;
        // Debug.Log("on cool down false? " + onCooldown);
    }
    // IEnumerator PlayerBlinkOrange()
    // {
    //     Color orange;
    //     ColorUtility.TryParseHtmlString("#C1440E", out orange);
    //     Color original = spriteRenderer.color;
    //     spriteRenderer.color = orange;
    //     yield return new WaitForSeconds(0.1f);
    //     spriteRenderer.color = original;
    // }

    // IEnumerator PlayerBlinkBlue()
    // {
    //     Color blue;
    //     ColorUtility.TryParseHtmlString("#5F9EA0", out blue);
    //     Color original = spriteRenderer.color;
    //     spriteRenderer.color = blue;
    //     yield return new WaitForSeconds(0.1f);
    //     spriteRenderer.color = original;
    // }

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
