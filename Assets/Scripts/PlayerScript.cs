using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D magpie;
    public globalVariables globalVariables;

    void Start()
    {
        magpie = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // no movement on start
        Vector3 direction = Vector3.zero;

        // player keyboard input for direction
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction.x += 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction.y += 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction.y -= 1;

        // this prevents faster diagonal movement
        direction.Normalize();

        // update player movement
        Vector3 newPosition = transform.position + direction * globalVariables.playerMovementSpeed * Time.deltaTime;

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
