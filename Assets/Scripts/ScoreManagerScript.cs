using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;

    // player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // add points to total score
        if (other.CompareTag("commonNPC"))
        {
            // TODO only score once, no repeated hits
            globalVariables.totalScore += 1;
            Debug.Log("hit common trigger: " + other.name);
            Debug.Log("total score: " + globalVariables.totalScore);
        }
        else if (other.CompareTag("uncommonNPC"))
        {
            // TODO only score once, no repeated hits
            globalVariables.totalScore += 2;
            Debug.Log("hit uncommon trigger: " + other.name);
            Debug.Log("total score: " + globalVariables.totalScore);
        }
        else
        {
            Debug.Log("hit untagged object");
            Debug.Log("total score: " + globalVariables.totalScore);
        }

        // take points off health score
        if (other.CompareTag("obstacle"))
        {
            // TODO only score once, no repeated hits
            globalVariables.healthScore -= 1;
            Debug.Log("hit obstacle: " + other.name);
            Debug.Log("total HEALTH score: " + globalVariables.healthScore);
        }

        if (globalVariables.healthScore == 0)
        {
            Debug.Log("YOU LOSE");
            Debug.Log("FINAL SCORE: " + globalVariables.totalScore);
        }

    }

    // player collides with a non-trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger: " + collision.gameObject.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }

    // private void checkHealthScore()
    // {

    // }
}
