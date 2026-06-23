using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerscript : MonoBehaviour
{
    [SerializeField] float RunSpeed = 6f;
    [SerializeField] public float JumpSpeed = 5f;
    //sets the variable runspeed and jumpspeed


    Vector2 moveInput;

    Rigidbody2D myRidgidbody;

    CapsuleCollider2D myBodyCollider2D;

    //this gives the compentes in scene a variable name to use in the script

    void Start()
    //this method gets the components of the ridgid
    //body and the capulase collied and loads them into the script for use
    {
        myRidgidbody = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
    }
    //this updates all the method in the method every frame
    void Update()
    {
        run();
    }

    void run()
    //this method takes the players vector2 value then has them move along the x axis
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * RunSpeed, myRidgidbody.velocity.y);

        myRidgidbody.velocity = playerVelocity;
    }

    void OnJump(InputValue value)
    //this method checks the players on the floor then allows the player to jump if condistion is met
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Walls")))
        {
            myRidgidbody.velocity += new Vector2(0f, JumpSpeed);
        }
    }
   


    
    









}

