using UnityEngine;

public class MoveObstacleScript : MonoBehaviour
{
    // common obstacle movement speed
    public float commonObstacleMovementSpeed = 2f;


    void Update()
    {
        if (tag == "obstacle")
        {
            // move prefab down the screen
            transform.position += Vector3.down * commonObstacleMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}
