using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float runspeed = 6f;
    static public float Lives = 3f;


    public float elapsedTime = 0f;
    public float elapsedTime1 = 0f;
    public float elapsedTime2 = 0f;

    Vector2 moveInput;

    Rigidbody2D myRidgidbody;

    CapsuleCollider2D myBodyCollider2D;

    [SerializeField] public float jumpspeed = 5f;

    public bool isAlive = false;

    public bool Hastouched = false;

    public bool Hastouched2 = false;

    public bool Hastouched1 = false;

    void Start()
    {
        myRidgidbody = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();

    }


    void Update()
    {
        run();
        Die();

        Timers();
        timers2();


    }
    void timers2()
    {

        if (Hastouched2 == true)
        {


            elapsedTime2 += Time.deltaTime;
            if (elapsedTime2 >= 30f)
            {
                jumpspeed = 15f;

                elapsedTime2 = 0f;

                Hastouched2 = false;
                // Change the run speed and stop further updates


            }
        }

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
                runspeed = 7f;

                elapsedTime = 0f;

                Hastouched = false;
                // Change the run speed and stop further updates
            }
        }
    }








    void OnMove(InputValue value)
    {
        
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        //this code takes the vector value and then moves my sprite 

    }

    void run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runspeed, myRidgidbody.velocity.y);

        myRidgidbody.velocity = playerVelocity;
        

        

       
    }

    void OnJump(InputValue value)
    {

        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            myRidgidbody.velocity += new Vector2(0f, jumpspeed);
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    //This method checks for collision and the correct object
    //then sets the condidtion for Timer to true and increase run speed
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Speedboost")))
        {

            Hastouched = true;

            runspeed = 12f;
            
        }
    }


    void Die()
    //this method checks id the player has died then resets the players transform
    //then calls the timers1 fuction
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Dangers")))
        {
            transform.position = new Vector2(-4.320046f, 1.201181f);
            Hastouched1 = true;

            Timers1();
        }
    }
    void Timers1()
    //this method checks if the players touched a danger then starts the timer
    //then is calls the death function from the gamesession manager
    {
        if (Hastouched1 == true)
        {
            elapsedTime1 += Time.deltaTime;
            if (elapsedTime1 >= 0.01388257f)
            {
                isAlive = true;
                
                Hastouched1 = false;

                FindObjectOfType<GameSessionManager>().Death();
                elapsedTime1 = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Jumpboost")))
        {


            Hastouched2 = true;
            //first checks to see if the player has collieded with a hazard or enimes

            jumpspeed = 30f;

            // Check if 30 seconds have passed
            
        }
        



    }









}



