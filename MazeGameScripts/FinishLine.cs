using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine.UIElements.Experimental;

public class FinishLine : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI PlayerTimeUI;

    ArrayList Scores;

    public bool PlayerComplete = false ;

    

    public static float PlayerTimeScore = 0;

    public static float PlayerTimeScoretemp = 0;



    BoxCollider2D myBodyCollider2D;
    //initalies all my variables


    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.dataPath + "/Scores.txt"))
        {
            Scores = new ArrayList(File.ReadAllLines(Application.dataPath + "/Scores.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Scores.txt", "");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTime();
        
    }

    void PlayerTime()
    //checks the player hasnt completed yet then contiunes the timer and updating the UI
    {
        if(PlayerComplete != true)
        {
            PlayerTimeScore += Time.deltaTime;

            PlayerTimeScoretemp += Time.deltaTime;

            PlayerTimeUI.text = PlayerTimeScoretemp.ToString();
        }
        else
        {
            File.WriteAllText("/Scores.txt", PlayerTimeScoretemp.ToString());

            PlayerTimeScoretemp = 0;

            SceneManager.LoadScene("MazeGameMenu");
        }
    }

    

   
       


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("MazeGameMenu");

        File.WriteAllText("/Scores.txt", PlayerTimeScoretemp.ToString());


        PlayerComplete = true;
    }
}
