using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class PlatformerEnd : MonoBehaviour
{
    public Button HOME;

    public TextMeshProUGUI CoinScore;

    //intializing varbiles to attch to objects

    // Start is called before the first frame update
    void Start()
    {
        HOME.onClick.AddListener(Home);
        //then i add a listener
        //so when the buttons pressed it calls the Home method

    }
    void Home()
    {
        SceneManager.LoadScene("GameModeSelection");
        //loads GameMode selection scene
    }

    // Update is called once per frame
    void Update()
    {
        CoinScore.text = (GameSessionManager.CoinScoreTotal).ToString();
        //set text equal to desired varibale every frame
    }

}
