using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public Button EasyBTN;
    public Button HardBTN;
    public Button ImpossibleBTN;
    //initalizing variables attached to button objects

    void Start()
    //called before the first frame
    {
        EasyBTN.onClick.AddListener(Easy);
        HardBTN.onClick.AddListener(Medium);
        ImpossibleBTN.onClick.AddListener(Impssible);
        //then i add a listener to each difficulty type button
        //so when the buttons pressed it calls the respective method

    }

    void Impssible()
    {
        SceneManager.LoadScene("Maze");
        //loads Impossible game mode scene
    }

    void Easy()
    {
        SceneManager.LoadScene("MazeEasy");
        //loads Easy game mode scene
    }

    void Medium()
    {
        SceneManager.LoadScene("MazeMedium");
        //loads Medium game mode scene
    }

}
