using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class LeaderBoard : MonoBehaviour
{

    string User = Login.UserINP.text;

    public static float Player_score = FinishLine.PlayerTimeScore;


    public Button HOME;

    public TextMeshProUGUI PLACE1;

    public TextMeshProUGUI PLACE2;

    public TextMeshProUGUI PLACE3;

    public TextMeshProUGUI PLACE4;

    public TextMeshProUGUI PLACE5;

    int X = 0;

    List<float> HIScores = new List<float>();



    void Start()
    {



        PLACE1.text = "10";
        PLACE2.text = HIScores[1].ToString();
        PLACE3.text = (HIScores[2]).ToString();
        PLACE4.text = (HIScores[3]).ToString();
        PLACE5.text = (HIScores[4]).ToString();
        
        foreach (var i in HIScores)
        {
            if (Player_score > i)
            {
                HIScores[X] = Player_score;
                PLACE1.text = HIScores[0].ToString();
            }
            else
            {
                X++;
            }
        }
    }


    private void Update()
    {

        foreach (var i in HIScores)
        {
            if (Player_score > i)
            {
                HIScores[X] = Player_score;
                PLACE1.text = HIScores[0].ToString();
            }
            else
            {
                X++;
            }
        }

        

    }

    // Start is called before the first frame update


    // Update is called once per frame

}
