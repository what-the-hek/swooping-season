using UnityEngine;
using System.Collections;
using TMPro;

public class MoveSpecialTargetsScript : MonoBehaviour
{
    public globalVariables globalVariables;
    // public bool wasCollected = false;
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
            if (tag == "cat1")
            {
                globalVariables.cat1Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit cat1!!!!!! ");
            }
            if (tag == "cat2")
            {
                globalVariables.cat2Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit cat2!!!!!! ");
            }
            if (tag == "cat3")
            {
                globalVariables.cat3Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit cat3!!!!!! ");
            }
            if (tag == "dog1")
            {
                globalVariables.dog1Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit dog1!!!!!! ");
            }
            if (tag == "dog2")
            {
                globalVariables.dog2Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit dog2!!!!!! ");
            }
            if (tag == "dog3")
            {
                globalVariables.dog3Unlocked = true;
                // wasCollected = true;
                Debug.Log("hit dog3!!!!!! ");
            }
        }
    }
}
