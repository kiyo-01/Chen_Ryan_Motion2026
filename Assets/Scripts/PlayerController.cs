using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool facingLeft = true;
    //horizontal move stuff
    public float maxSpeed = 5f;
    public float accelTime = 0.5f;
    private float accel;
    //vertical jump stuff
    public float apexJHeight = 4f;
    public float apexJTime = 0.4f;
    private float initialJVelo = 20f;
    private float gravity;
    private bool wasJTriggered = false;

    public float groundCheckDistance = 1f;
    public LayerMask groundLayer;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        accel = maxSpeed / accelTime;
        gravity = -2 * apexJHeight / (apexJTime * apexJTime);
        initialJVelo = 2 * apexJHeight / apexJTime;
    }

    void FixedUpdate()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.

        //check if the player is pressing left or right and set the playerInput accordingly
        Vector2 playerInput = new Vector2();
        if (Keyboard.current.aKey.isPressed)
        {
            playerInput.x = -1;
            facingLeft = true;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            playerInput.x = 1;
            facingLeft = false;
        }
        else
        {
            playerInput.x = 0;
        }

        MovementUpdate(playerInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame && IsGrounded() || Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            wasJTriggered = true;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            gravity *= 2;
        } 
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
            {
                gravity /= 2;
            }

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = rb.linearVelocity;

        if (playerInput.x != 0)
        {
            //accelerate the player in the direction of the input
            newVelocity.x += playerInput.x * accel * Time.deltaTime;
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        }
        else
        {
            //if the player is not pressing any input, slow down the player to a stop
            newVelocity.x = 0;
        }

        //if (Keyboard.current.wKey.wasPressedThisFrame && IsGrounded())
        //{
        //    newVelocity.y = initialJVelo;
        //}

        //apply the gravity that we calc over time

        if (IsGrounded() != true)
        {
            newVelocity.y += gravity * Time.deltaTime;
        }
        //if the player provides the input for the jump, give initial jump velocity

        if (wasJTriggered)
        {
            newVelocity.y = initialJVelo;
            wasJTriggered = false;
        }
        
        rb.linearVelocity = newVelocity;
    }

    public bool IsWalking()
    {
        //check if the player is moving (figured out you can just throw them into one
        //originally didnt have the 0.05f but it was too sensitive and would sometimes trigger when the player was not moving? wack
        return Mathf.Abs(rb.linearVelocity.x) > 0.05f;
    }
    public bool IsGrounded()
    {
        //https://youtu.be/xH-x7YFS7vU?si=Vbr8rG3lbHd7Oukc
        //found a video for how to use layermask
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    public FacingDirection GetFacingDirection()
    {
        if (facingLeft == false)
        {
            return FacingDirection.right;
        }

        return FacingDirection.left; //default direction
    }
}
