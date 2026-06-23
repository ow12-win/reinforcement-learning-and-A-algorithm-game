using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    
    [SerializeField] float RotateSpeed = 60f;
    [SerializeField] float movespeed = 4f;



   

    CapsuleCollider2D myBodyCollider2D;


    public float elapsedTime = 0f;

    

    

    public bool Hastouched = false;


    void Start()
    {
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HSpeedfloat = Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime;
        float Speedfloat = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;
        //takes the standerent WASD inputs and converts them to vlaues

        transform.Translate(HSpeedfloat, 0, 0);
        transform.Translate(0, Speedfloat, 0);
        //sets players transform to the value previously determined

        Timers();
    }



    void Timers()
    //this method checks the condition previous is true
    //starts the timer and after 30s then resets all variable to previous values
    {
        if (Hastouched == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 30f)
            {
                movespeed = 4f;

                RotateSpeed = 4f;

                elapsedTime = 0f;

                Hastouched = false;
                // Change the run speed and stop further updates
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    //This method checks for collision and the correct object
    //then sets the condidtion for Timer to true and increase run speed
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Speedboost")))
        {

            Hastouched = true;

            movespeed = 10f;

            RotateSpeed = 10f;

        }
    }
}

