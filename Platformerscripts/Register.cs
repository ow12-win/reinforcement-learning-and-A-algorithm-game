using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Register : MonoBehaviour
{

    public InputField usernameInput;
    public InputField PasswordInput;
    public Button registerButton;
    public Button goTOLoginButton;

    ArrayList values;










    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(writeStuffToFile);
        goTOLoginButton.onClick.AddListener(goTOLoginScene);
        if(File.Exists(Application.dataPath + "/Values.txt"))
        {
            values = new ArrayList(File.ReadAllLines(Application.dataPath + "/Values.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Values.txt", "");
        }
    }

    void goTOLoginScene()
    {
        SceneManager.LoadScene("loginage");
    }

    void writeStuffToFile()
    {
        bool isExists = false;

        values = new ArrayList(File.ReadAllLines(Application.dataPath + "/Values.txt"));

        foreach (var i in values)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }
        if (isExists)
        {
            Debug.Log($"Username {usernameInput.text} already exists");
        }
        else
        {
            values.Add(usernameInput.text + "," + PasswordInput.text);
            File.WriteAllLines(Application.dataPath + "/Values.txt", (string[])values.ToArray(typeof(string)));
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
