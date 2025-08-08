using UnityEngine;

public class MoveBoostScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public int hitCount;
    // public int totalBoostHits;
    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        // hitCount = 0;
        // totalBoostHits = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            globalVariables.boostsConsumed++;
            Debug.Log("BOOSTS CONSUMED: " + globalVariables.boostsConsumed);

            // CheckHits();
        }
    }
    void Update()
    {
        if (tag == "boost")
        {
            transform.position += Vector3.down * globalVariables.commonBoostMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
    // public void CheckHits()
    // {
    //     if (hitCount > totalBoostHits)
    //     {
    //         totalBoostHits = hitCount;
    //         // Debug.Log("total boosts consumed: " + totalBoostHits);
    //     }
    // }
}
