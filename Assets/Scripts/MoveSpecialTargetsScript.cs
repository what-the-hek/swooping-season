using UnityEngine;

public class MoveSpecialTargetsScript : MonoBehaviour
{

    public globalVariables globalVariables;
    // public CollisionDetectionScript minusScore;
    public bool wasCollected = false;
    public int hitCount;
    public int totalBoostHits;

    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        // minusScore = player.GetComponent<CollisionDetectionScript>();
        hitCount = 0;
        totalBoostHits = 0;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO add some logic here about unlocking achievements etc...
            wasCollected = true;
            Debug.Log("hit the cat!!!!!! ");
            // spriteRenderer.sprite = hitSprite;
            // animator.SetTrigger("hit");
            hitCount++;
            CheckHits();
        }
    }

    public void Update()
    {
        // if (tag == "npc-back")
        // {
        // move prefab down the screen
        transform.position += Vector3.down * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        // }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -6.5)
        {
            if (!wasCollected)
            {
                Debug.Log("!! WHOOPS !! missed the CAT");
                // minusScore.MinusScore();
            }
            Destroy(gameObject);
        }
    }

    public void CheckHits()
    {
        if (hitCount > totalBoostHits)
        {
            totalBoostHits = hitCount;
            Debug.Log("total cats hit: " + totalBoostHits);
        }
    }
}
