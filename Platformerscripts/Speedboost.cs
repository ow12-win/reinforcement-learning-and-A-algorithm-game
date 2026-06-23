using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedboost : MonoBehaviour
{

    CircleCollider2D myBodyCollider2D;
    // Start is called before the first frame update

    public bool Newtimer = false;

    public float elapsedTime = 0f;

    void Update()
    //this calls the timers method every frame
    {
        Timers();
    }

    void Timers()
    //this is used to start the timer and checks if the time reaches 2
    //then destroying the objects
    {
        if (Newtimer == true)
        {

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 2f)
            {

                elapsedTime = 0f;

                Newtimer = false;
                
                Destroy(gameObject);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    //checks for collision and matches the condition for the timer
    {
        Newtimer = true;
    }
}
