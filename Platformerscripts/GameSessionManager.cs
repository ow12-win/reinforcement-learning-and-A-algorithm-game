using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSessionManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Score;
    static public int CoinScoreTotal = 0;


    //here i initalized the CoinScoreTotal and score variable
    public void AddToScore(int pointsToAdd)
    //this method makes a running total of the coin score
    //then updates the UI it to check outputs
    {
        CoinScoreTotal += pointsToAdd;
        
        Score.text = CoinScoreTotal.ToString();
    }

    static public int PlayerLives = 3;
    [SerializeField] TextMeshProUGUI Lives;



    public void Death()
    //this substracts one from theplayers live and updates the UI
    {
        transform.position = new Vector2(-4.320046f, 1.201181f);
        PlayerLives--;
        Lives.text = PlayerLives.ToString();
    }

    public void AddLife()
    //adds one to the players life
    //then updates the UI
    {
        PlayerLives++;
        Lives.text = PlayerLives.ToString();
    }





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Lives.text = PlayerLives.ToString();
        Score.text = CoinScoreTotal.ToString();
    }
}
