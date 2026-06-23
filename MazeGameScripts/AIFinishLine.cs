using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIFinishLine : MonoBehaviour
{
    

    [SerializeField] TextMeshProUGUI AITimeUI;

    

    public bool AIComplete = false;

    

    public static float AITimeScore = 0;

    BoxCollider2D myBodyCollider2D;
    //initalies all my variables


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        AITime();
    }

   

    void AITime()
    //checks the AI hasnt completed yet then contiunes the timer and updating the UI
    {
        if (AIComplete != true)
        {
            AITimeScore += Time.deltaTime;

            AITimeUI.text = AITimeScore.ToString();
        }
        else
        {
            Debug.Log(AITimeScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //once collied sets conditions to true
    {
        

        AIComplete = true;
    }
}
