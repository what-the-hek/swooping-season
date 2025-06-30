using UnityEngine;

public class MoveBoostScript : MonoBehaviour
{
    // common boost movement speed
    public float commonBoostMovementSpeed = 2f;


    void Update()
    {
        if (tag == "boost")
        {
            // move prefab down the screen
            transform.position += Vector3.down * commonBoostMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}
