using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool facingLeft = true;
    
    public float maxSpeed = 5f;
    public float accelTime = 0.5f;
    private float accel;

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
    }

    // Update is called once per frame
    void Update()
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

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = rb.linearVelocity;

        if (playerInput.x != 0)
        {
            //accelerate the player in the direction of the input
            newVelocity += playerInput.x * accel * Time.deltaTime * Vector2.right;
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        }
        else
        {
            //if the player is not pressing any input, slow down the player to a stop
            newVelocity = Vector2.zero;
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
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return ground.collider != null;
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
