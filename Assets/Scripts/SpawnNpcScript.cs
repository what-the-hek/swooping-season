using UnityEngine;

public class SpawnNpcScript : MonoBehaviour
{

    // spawn a common npc at random intervals between x - y
    // public float spawnCommonInterval = 4f;
    // spawn an uncommon npc at random intervals between x - y
    // public float spawnUncommonNpcInterval = 2f;

    // common npc movement speed
    public float commonNpcMovementSpeed = 4f;
    // uncommon npc movement speed
    // public float uncommonNpcMovementSpeed = 2f;


    // void Start()
    // {
        
    // }

    void Update()
    {
        transform.position += Vector3.down * commonNpcMovementSpeed * Time.deltaTime;
    }
}
