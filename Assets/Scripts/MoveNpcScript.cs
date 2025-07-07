using UnityEngine;

public class MoveNpcScript : MonoBehaviour
{

    public globalVariables globalVariables;
    public CollisionDetectionScript minusScore;
    //     // common npc movement speed
    // public float commonNpcMovementSpeed = 4f;

    // // uncommon npc movement speed
    // public float uncommonNpcMovementSpeed = 2f;
    public bool wasCollected = false;

    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        minusScore = player.GetComponent<CollisionDetectionScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wasCollected = true;
            Debug.Log("collected npc: " + wasCollected);
        }
    }

    public void Update()
    {
        if (tag == "commonNPC")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        }
        if (tag == "uncommonNPC")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.uncommonNpcMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -6.5)
        {
            if (!wasCollected)
            {
                Debug.Log("!! WHOOPS !! missed one");
                minusScore.MinusScore();
            }
            Destroy(gameObject);
        }
    }
}
