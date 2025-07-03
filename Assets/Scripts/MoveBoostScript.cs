using UnityEngine;

public class MoveBoostScript : MonoBehaviour
{
    public globalVariables globalVariables;

    void Update()
    {
        if (tag == "boost")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.commonBoostMovementSpeed * Time.deltaTime;
        }

        // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
        if (transform.position.y <= -19)
        {
            Destroy(gameObject);
        }
    }
}
