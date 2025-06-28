using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D magpie;

    void Start()
    {
        magpie = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // variable for player movement
        Vector3 newPosition = transform.position;

        // keyboard input for player movement
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left");
            newPosition += new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right");
            newPosition += new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Up");
            newPosition += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Down");
            newPosition += new Vector3(0, -1, 0);
        }

        // get screen bounds in world units
        Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // 'clamp' new position to stay within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, lowerLeft.x, upperRight.x);
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLeft.y, upperRight.y);

        // update player position
        transform.position = newPosition;
    }

}
