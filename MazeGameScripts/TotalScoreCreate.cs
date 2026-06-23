using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class TotalScoreCreate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TotalScore;

    public FinishLine finishLine;
    public GameSessionManager sessionManager;

    public static float TotalScore1;

    //loads the other script from which varibales i need to use are

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    //allows for real time calculating of the total score from all the scripts and updates the UI
    {
        float TotalScore1 = (GameSessionManager.CoinScoreTotal / FinishLine.PlayerTimeScore) * 1000;



        
        TotalScore.text = (((int)TotalScore1)).ToString();
    }
}
