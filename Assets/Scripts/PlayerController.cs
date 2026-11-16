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
            newVelocity += playerInput.x * accel * Time.deltaTime * Vector2.right;
        } 
        else
        {
            newVelocity = Vector2.zero;
        }
        rb.linearVelocity = newVelocity;
    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        if (facingLeft == false)
        {
            return FacingDirection.right;
        }
        else if (facingLeft == true)
        {
            return FacingDirection.left;
        }

        return FacingDirection.left; //default direction
    }
}
