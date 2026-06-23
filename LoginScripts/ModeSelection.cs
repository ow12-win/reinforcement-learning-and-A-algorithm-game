using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour
{


    public Button MazeBTN;
    public Button PlatformerBTN;
    public Button LeaderBoardBTN;

    //intializing varbiles to attch to objects

    void Start()
    {
        MazeBTN.onClick.AddListener(MazeRacer);
        
        PlatformerBTN.onClick.AddListener(Platformer);
        LeaderBoardBTN.onClick.AddListener(LeaderBoard);
        //adds a listen so when the buttons pressed
        //the method is called
    }
    void LeaderBoard()
    //loads leaderboard scene
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    void MazeRacer()
    //loads the difficulty selection scene
    {
        SceneManager.LoadScene("DifficultySelection");
    }

    void Platformer()
    //loads the platformer scene
    {
        SceneManager.LoadScene("Platformer");
    }

}
