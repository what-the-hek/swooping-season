using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public globalVariables globalVariables;
    public GameObject backgroundPrefab;
    private bool hasSpawned = false;

    void Update()
    {
        // scroll down background
        transform.Translate(Vector2.down * globalVariables.backgroundScrollSpeed * Time.deltaTime);
        // spawn the next background when current reaches border limit
        if (!hasSpawned && transform.position.y <= -5)
        {
            // calculate spawn position of next background based on sprite size and current background's position
            Vector3 newPosition = new Vector3(0, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y, 0);
            Instantiate(backgroundPrefab, newPosition, Quaternion.identity);
            hasSpawned = true;
        }
        // once the top of the current background is off the screen, destroy the background object
        if (transform.position.y <= -30)
        {
            Destroy(gameObject);
        }
    }
}