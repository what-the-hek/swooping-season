using UnityEngine;
using System.Collections;
using TMPro;

public class MoveSpecialTargetsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    public bool wasCollected = false;
    public void Update()
    {
        transform.position += Vector3.down * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        transform.position += Vector3.right * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        if (transform.position.y <= -6.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // TODO add some logic here about unlocking achievements etc...
            globalVariables.cat1Unlocked = true;
            wasCollected = true;
            Debug.Log("hit the cat/dog!!!!!! ");
        }
    }
    // on collision
    // if tag == cat1
    // global.cat1 = true
    // cat1 = true
}
