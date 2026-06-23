using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public TMP_InputField username;


    public void Buttonclicked()
    {
        if (username.text == "oscar")
        {
            SceneManager.LoadScene("Platformer");
        }


    }

}
