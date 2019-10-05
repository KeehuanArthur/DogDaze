<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player")]
    public float playerSpeed = 10;
    public Vector2 moveVelocity;
    public Vector2 moveInput;

    Rigidbody2D playerBody;
    SpriteRenderer playerSprite;

    [Header("Projectile")] //From here
    public Rigidbody2D projectile;
    public float projectileSpeed = 15;
    private Vector3 target; //To here



/*
        public float speed = 15;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    */




    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        // playerSprite = GetComponent<SpriteRenderer>();
        target = projectile.transform.position; // here
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void PlayerInput()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        if (hAxis != 0f)
        {
            moveInput = new Vector2(hAxis, 0f);
            if (vAxis != 0f)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else if (vAxis != 0f)
        {
            moveInput = new Vector2(0f, vAxis);
            if (hAxis != 0f)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else // Infinite movement if this else isnt here....
            moveInput = new Vector2(hAxis, vAxis);

        moveVelocity = moveInput.normalized * playerSpeed;


        // Projectile movement
        
        if (Input.GetMouseButtonDown(0))
        {
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D newProjectile;
            newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            target.z = newProjectile.transform.position.z;
            newProjectile.velocity = newProjectile.transform.TransformDirection(target);
            //newProjectile.transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * 10);
            
        }
        //newProjectile.transform.position = Vector3.MoveTowards(newProjectile.transform.position, target, projectileSpeed * Time.deltaTime);

        //To here

    }
    

    public void MovePlayer()
    {
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.fixedDeltaTime);
    }


}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player")]
    public float playerSpeed = 10;
    public Vector2 moveVelocity;
    public Vector2 moveInput;

    Rigidbody2D playerBody;
    SpriteRenderer playerSprite;

    [Header("Projectile")] //From here
    public Rigidbody2D projectile;
    public float projectileSpeed = 15;
    private Vector3 target; //To here



/*
        public float speed = 15;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    */




    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        // playerSprite = GetComponent<SpriteRenderer>();
        target = projectile.transform.position; // here
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void PlayerInput()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        if (hAxis != 0f)
        {
            moveInput = new Vector2(hAxis, 0f);
            if (vAxis != 0f)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else if (vAxis != 0f)
        {
            moveInput = new Vector2(0f, vAxis);
            if (hAxis != 0f)
                moveInput = new Vector2(hAxis, vAxis);
        }

        else // Infinite movement if this else isnt here....
            moveInput = new Vector2(hAxis, vAxis);

        moveVelocity = moveInput.normalized * playerSpeed;


        // Projectile movement
        
        if (Input.GetMouseButtonDown(0))
        {
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D newProjectile;
            newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            target.z = newProjectile.transform.position.z;
            newProjectile.velocity = newProjectile.transform.TransformDirection(target);
            //newProjectile.transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * 10);
            
        }
        //newProjectile.transform.position = Vector3.MoveTowards(newProjectile.transform.position, target, projectileSpeed * Time.deltaTime);

        //To here

    }
    

    public void MovePlayer()
    {
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.fixedDeltaTime);
    }


}
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
