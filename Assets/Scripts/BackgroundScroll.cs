using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public GameObject backgroundPrefab;
    public float scrollSpeed = 2f;
    private bool hasSpawned = false;

    void Update()
    {
        // scroll down background
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        // spawn the next background when current reaches border limit
        if (!hasSpawned && transform.position.y <= -5)
        {
            // calculate spawn position of next background based on sprite size and current background's position
            Vector3 newPosition = new Vector3(0, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y, 0);
            Instantiate(backgroundPrefab, newPosition, Quaternion.identity);
            hasSpawned = true;
        }
        // // once the top of the current background is off the screen, destroy the background object
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}