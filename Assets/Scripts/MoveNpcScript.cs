using UnityEngine;

public class MoveNpcScript : MonoBehaviour
{
        // common npc movement speed
    public float commonNpcMovementSpeed = 4f;

    // uncommon npc movement speed
    public float uncommonNpcMovementSpeed = 2f;

    void Update()
    {
        if (tag == "commonNPC")
        {
            // move prefab down the screen
            transform.position += Vector3.down * commonNpcMovementSpeed * Time.deltaTime;
        }
        if (tag == "uncommonNPC")
        {
            // move prefab down the screen
            transform.position += Vector3.down * uncommonNpcMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}
