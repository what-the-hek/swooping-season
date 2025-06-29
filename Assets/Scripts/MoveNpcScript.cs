using UnityEngine;

public class MoveNpcScript : MonoBehaviour
{
        // common npc movement speed
    public float commonNpcMovementSpeed = 4f;

    // uncommon npc movement speed
    // public float uncommonNpcMovementSpeed = 2f;

    void Update()
    {
        // move prefab down the screen
        transform.position += Vector3.down * commonNpcMovementSpeed * Time.deltaTime;

        // once the prefab is off the screen, destroy it
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}
