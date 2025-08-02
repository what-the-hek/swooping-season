using UnityEngine;
using System.Collections;
using TMPro;

public class MoveSpecialTargetsScript : MonoBehaviour
{
    public void Update()
    {
        transform.position += Vector3.down * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        transform.position += Vector3.right * globalVariables.commonNpcMovementSpeed * Time.deltaTime;
        if (transform.position.y <= -6.5)
        {
            Destroy(gameObject);
        }
    }
}
