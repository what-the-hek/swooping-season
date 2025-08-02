using UnityEngine;
using System.Collections;
using TMPro;

public class AchievementsManager : MonoBehaviour
{
    public globalVariables globalVariables;
    // public CollisionDetectionScript minusScore;
    // public DisplayTrophiesScript displayTrophies;
    public bool wasCollected = false;
    public int hitCount;
    public int totalBoostHits;
    public bool gotCat1 = false;
    public bool gotCat2 = false;
    public bool gotCat3 = false;
    // public GameObject trophy;
    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        hitCount = 0;
        totalBoostHits = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // TODO add some logic here about unlocking achievements etc...
            wasCollected = true;
            Debug.Log("hit the cat!!!!!! ");

            hitCount++;
            CheckHits();
            UnlockTrophy();
        }
    }
    public void CheckHits()
    {
        if (hitCount > totalBoostHits)
        {
            totalBoostHits = hitCount;
            Debug.Log("total cats hit: " + totalBoostHits);
        }
    }

    public void UnlockTrophy()
    {
        // TODO add achievements manager? 
        if (tag == "cat1")
        {
            gotCat1 = true;
        }
        if (tag == "cat2")
        {
            gotCat2 = true;
        }   
        if (tag == "cat3")
        {
            gotCat3 = true;
        }     
    }
}
