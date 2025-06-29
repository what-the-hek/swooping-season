using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    public globalVariables globalVariables;

    // player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        globalVariables.totalScore += 1;
        Debug.Log("hit trigger: " + other.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }

    // player collides with a non-trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger: " + collision.gameObject.name);
        Debug.Log("total score: " + globalVariables.totalScore);
    }
}
