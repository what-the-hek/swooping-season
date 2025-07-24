using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D magpie;
    public globalVariables globalVariables;
    private Animator animator;

    void Start()
    {
        magpie = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        float moveSpeed = 1f;
        float dodgeBoost = 6f;

        bool isDodging = Input.GetKey(KeyCode.Space);
        
        bool movingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        animator.SetBool("isMovingLeft", movingLeft);

        bool movingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        animator.SetBool("isMovingRight", movingRight);

        bool movingBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        animator.SetBool("isMovingBack", movingBack);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= isDodging ? moveSpeed + dodgeBoost : moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetTrigger("left-correct");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction.x += isDodging ? moveSpeed + dodgeBoost : moveSpeed;
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetTrigger("right-correct");
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction.y += isDodging ? moveSpeed + dodgeBoost : moveSpeed;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction.y -= isDodging ? moveSpeed + dodgeBoost : moveSpeed;
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetTrigger("back-correct");
        }


        // this prevents faster diagonal movement
        direction.Normalize();

        float baseSpeed = globalVariables.playerMovementSpeed;
        float finalSpeed = isDodging ? baseSpeed + dodgeBoost : baseSpeed;

        Vector3 newPosition = transform.position + direction * finalSpeed * Time.deltaTime;

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
