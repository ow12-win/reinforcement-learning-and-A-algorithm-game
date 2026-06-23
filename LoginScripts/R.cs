using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class R : MonoBehaviour
{

    public InputField UserINP;
    public InputField PasINP;
    public Button RegBTN;
    public Button GTLBTN;

    public TextMeshProUGUI Warnings;

    //creating variables to be used
    

    ArrayList Creds;

    // Start is called before the first frame update
    void Start()
    {
        RegBTN.onClick.AddListener(WriteCredentials);
        GTLBTN.onClick.AddListener(GTLP);

        //sets so it checks for the state of the button
        //and if its true calls the method in brackets

        FileExist();
        //calls file exists method
    }

    void GTLP()
    //loads loginpage from my scenes when called
    {
        SceneManager.LoadScene("LoginPage");
    }

    void FileExist()
    //this method checks if the file path is already on the devices local storage
    {
        if (File.Exists(Application.dataPath + "/Cred.txt"))
        {
            Creds = new ArrayList(File.ReadAllLines(Application.dataPath + "/Cred.txt"));
            //adds all data from the text file into the arraylist so it can be searched
            //more efficently

        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Cred.txt", "");
            //creates a file is not already
        }
    }


    void WriteCredentials()
    //methos used to write the players data to the text file
    {
        bool Exists = false;
        //initalizes new boolean variable

        Creds = new ArrayList(File.ReadAllLines(Application.dataPath + "/Cred.txt"));

        //adds all data from the text file into the arraylist so it can be searched
        //more efficently
        string Validation = PasINP.text;

        //making a temp variable for vailidation later on
        foreach (var i in Creds)
        //loops through the array list
        {
            if (i.ToString().Contains(UserINP.text))
            //if the string is in the file already sets exists to true
            {
                Exists = true;
            }
        }
        if (Exists)
        //warnning text is changed to show usernames taken
        {
            Warnings.text = "UserName is taken";
        }
        else
        //if username isnt taken
        {
            if (Validation.Length<8)
            //validation checks if password is long enough
            {
                Warnings.text = "pasword needs to be at least 8 characters";
            }
            else
            //if passwords long enough
            {
                bool containsInt = Validation.Any(char.IsDigit);
                //as a boolean value to check if the input has a number

                if (containsInt)
                //if true it then adds details to a file
                {
                    Creds.Add(UserINP.text + ":" + PasINP.text);
                    File.WriteAllLines(Application.dataPath + "/Cred.txt", (String[])Creds.ToArray(typeof(string)));
                    Warnings.text = "Acoount Registered";
                }
                else
                //otherwise produces a warning
                {
                    Warnings.text = "pasword needs to contain a number";
                }
               
            }
        }
    }
}