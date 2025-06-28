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

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left");
            transform.position += new Vector3 (-1, 0, 0);
            // CheckMovement("Left");
            // animator.SetTrigger("LeftMove");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right");
            transform.position += new Vector3 (1, 0, 0);
            // CheckMovement("Right");
            // animator.SetTrigger("RightMove");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Up");
            transform.position += new Vector3 (0, 1, 0);
            // CheckMovement("Up");
            // animator.SetTrigger("ButtWiggle");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Down");
            transform.position += new Vector3 (0, -1, 0);
            // CheckMovement("Down");
            // animator.SetTrigger("SassyLegs");
        }

    }

}
