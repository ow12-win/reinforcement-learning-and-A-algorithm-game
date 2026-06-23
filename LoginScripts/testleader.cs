using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class testleader : MonoBehaviour
{
    public Button HOME;

    public TextMeshProUGUI CoinScore;

    public TextMeshProUGUI CoinScore1;

    public TextMeshProUGUI CoinScore2;

    public TextMeshProUGUI CoinScore3;

    public TextMeshProUGUI CoinScore4;


    float data;



    // Start is called before the first frame update
    void Start()
    {

        if (FinishLine.PlayerTimeScore < data)
        {
            PlayerPrefs.SetFloat("data", FinishLine.PlayerTimeScore);
            CoinScore.text = (data).ToString();



            Debug.Log(data);
        }

        HOME.onClick.AddListener(Home); 

    }
    void Home()
    {
        SceneManager.LoadScene("GameModeSelection");
    }
    private void setFloat(float data)
    {
        PlayerPrefs.SetFloat("data", FinishLine.PlayerTimeScore);
    }
    // Update is called once per frame
    void Update()
    {


        


    }
    

}
