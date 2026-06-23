using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int PointsForCoin = 100;

    int CollectedPoints;

    //initializes all varibales needed for the method

    void OnTriggerEnter2D(Collider2D other)
    //this method checks that what the coin has colllied with is the player
    //then calles a separate method from the gamesession manager then destorying the game object
    {
        if (other.tag == "Player")
        {

            FindObjectOfType<GameSessionManager>().AddToScore(PointsForCoin);


            int CollectedPoints =+100;
            Debug.Log(CollectedPoints);
            Destroy(gameObject);

        }
    }


    
}
