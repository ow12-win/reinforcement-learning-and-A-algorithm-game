using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro; // Import TextMeshPro namespace
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class    newscript345 : MonoBehaviour
{

    public TextMeshProUGUI CoinScore;

    public TextMeshProUGUI CoinScore1;

    public TextMeshProUGUI CoinScore2;

    public TextMeshProUGUI CoinScore3;

    public TextMeshProUGUI CoinScore4;


    public Button EnterInfo;

    public InputField UserINP;

    public InputField TimeINP;

    ArrayList LeaderBoardvars;
    // Dictionary to hold player names and their scores
    private void Start()
    {
        EnterInfo.onClick.AddListener(WriteCredentials);


        FileExist();
    }

    private void Update()
    {
        UpdatingLeaderBoard();
    }

    void FileExist()
    //this method checks if the file path is already on the devices local storage
    {
        if (File.Exists(Application.dataPath + "/HIScores.txt"))
        {
            LeaderBoardvars = new ArrayList(File.ReadAllLines(Application.dataPath + "/HIScores.txt"));
            //adds all data from the text file into the arraylist so it can be searched
            //more efficently

        }
        else
        {
            File.WriteAllText(Application.dataPath + "/HIScores.txt", "");
            //creates a file is not already
        }
    }

    void WriteCredentials()
    //methos used to write the players data to the text file
    {

        //initalizes new boolean variable

        LeaderBoardvars = new ArrayList(File.ReadAllLines(Application.dataPath + "/HIScores.txt"))
        {
            //adds all data from the text file into the arraylist so it can be searched
            //more efficently


            UserINP.text + ":" + TimeINP.text
        };

        Debug.Log(LeaderBoardvars);




        File.WriteAllLines(Application.dataPath + "/HIScores.txt", (String[])LeaderBoardvars.ToArray(typeof(string)));
    }

    void UpdatingLeaderBoard()
    {




        LeaderBoardvars = new ArrayList(File.ReadAllLines(Application.dataPath + "/HIScores.txt"));

        //adds to the creds array list so standared porerations can be proformed

        var sortedList = LeaderBoardvars.Cast<string>().OrderBy(item => float.Parse(item));


        CoinScore.text = 9999.ToString();

        CoinScore4.text = 9999.ToString();

        CoinScore3.text = 9999.ToString();

        CoinScore2.text = 9999.ToString();

        CoinScore1.text = 9999.ToString();


        foreach (var i in sortedList)
        //loops through all variable/ lines in the file
        {

            




            float tes = float.Parse(i.ToString().Substring(i.ToString().IndexOf(":") + 1));

            float test = float.Parse(TimeINP.text);

            if (tes < test)
            //uses and if statment to essetially parse each side of the colons
            //where there indivdually evaluated for a match
            {
                CoinScore.text = test.ToString();

                CoinScore4.text = CoinScore3.text;

                CoinScore3.text = CoinScore2.text;

                CoinScore2.text = CoinScore1.text;

                CoinScore1.text = tes.ToString();
                



                //sets is exists to true as the user exisits
                break;
            }
        }
    }
}
