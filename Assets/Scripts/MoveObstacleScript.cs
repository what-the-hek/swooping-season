using UnityEngine;

public class MoveObstacleScript : MonoBehaviour
{

    public globalVariables globalVariables;

    void Update()
    {
        if (tag == "obstacle")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.commonObstacleMovementSpeed * Time.deltaTime;
            // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
            // if (transform.position.y <= -19)
            // {
            //     Destroy(gameObject);
            // }
        }

        if (tag == "carRight")
        {
            // move prefab down the screen
            transform.position += Vector3.down * globalVariables.carRightMovementSpeed * Time.deltaTime;
            // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
            // if (transform.position.y <= -19)
            // {
            //     Destroy(gameObject);
            // }
        }

        if (tag == "carLeft")
        {
            // move prefab up the screen
            transform.position += Vector3.up * globalVariables.carLeftMovementSpeed * Time.deltaTime;
            // once the prefab is off the screen, destroy it **TODO change this so it is responsive to any screen size
            // if (transform.position.y >= 25)
            // {
            //     Destroy(gameObject);
            // }
        }

        if (tag == "carRight" && transform.position.y <= -19 || tag == "obstacle" && transform.position.y <= -19)
        {
            Destroy(gameObject);
        }

        if (tag == "carLeft" && transform.position.y >= 25)
        {
            Destroy(gameObject);
        }
    }
}
