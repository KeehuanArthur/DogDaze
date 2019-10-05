using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    public float playerSpeed = 10;
    public Vector2 moveVelocity;
    public Vector2 moveInput;

    Rigidbody2D playerBody;
    SpriteRenderer playerSprite;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void PlayerInput ()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        if (hAxis != 0)
        {
            moveInput = new Vector2(hAxis, 0f);
            if (vAxis != 0)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else if (vAxis != 0)
        {
            moveInput = new Vector2(0f, vAxis);
            if (hAxis != 0)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else // Infinite movement if this else isnt here....
            moveInput = new Vector2(hAxis, vAxis);

        moveVelocity = moveInput.normalized * playerSpeed;

        
    }

    public void MovePlayer()
    {
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.fixedDeltaTime);
    }

   
}
