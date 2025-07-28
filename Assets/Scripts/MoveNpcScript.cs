using UnityEngine;

public class MoveNpcScript : MonoBehaviour
{

    public globalVariables globalVariables;
    public CollisionDetectionScript minusScore;
    //     // common npc movement speed
    // public float commonNpcMovementSpeed = 4f;

    // // uncommon npc movement speed
    // public float npcFrontMovementSpeed = 2f;
    public bool wasCollected = false;
    public int hitCount;

    // public Sprite defaultSprite;
    // public Sprite hitSprite;

    // private SpriteRenderer spriteRenderer;
    private Animator animator;

    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        minusScore = player.GetComponent<CollisionDetectionScript>();

        // spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = defaultSprite;
        animator = GetComponent<Animator>();
        hitCount = 0;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wasCollected = true;
            // Debug.Log("collected npc: " + wasCollected);
            // spriteRenderer.sprite = hitSprite;
            animator.SetTrigger("hit");
            hitCount++;
            CheckHits();
        }
    }

    public void Update()
    {
        if (tag == "npc-back")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        }
        if (tag == "npc-front")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.npcFrontMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -6.5)
        {
            if (!wasCollected)
            {
                // Debug.Log("!! WHOOPS !! missed one");
                minusScore.MinusScore();
            }
            Destroy(gameObject);
        }
    }

    public void CheckHits()
    {
        if (hitCount > globalVariables.targetHits)
        {
            globalVariables.targetHits = hitCount;
        }
    }
}
