using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    // player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit trigger - " + other.name);
    }

    // player collides with a non-trigger collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit non-trigger - " + collision.gameObject.name);
    }
}
