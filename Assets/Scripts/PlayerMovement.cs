using System;
using System.Collections;
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
    public GameMaster gameMaster;

    [Header("Projectile")] //From here
    private Vector3 target; //To here
    public Rigidbody2D[] Items;
    Rigidbody2D currentItem;

    


    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        gameMaster = FindObjectsOfType<GameMaster>()[0];
        // playerSprite = GetComponent<SpriteRenderer>();
        //target = projectile.transform.position; // here
    }

    private void Update()
    {
        PlayerInput();
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        MovePlayer();
        //Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && currentItem == Items[0])   // Useful for laser
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D newCurrentItem;
            newCurrentItem = Instantiate(currentItem, transform.position, Quaternion.identity);
            target.z = newCurrentItem.transform.position.z;
            newCurrentItem.transform.position = target;
            Destroy(newCurrentItem.gameObject, 3.0f);
        }

        if (Input.GetMouseButtonDown(0) && currentItem == Items[1])   // Useful for tennisball
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D newCurrentItem;
            newCurrentItem = Instantiate(currentItem, transform.position, Quaternion.identity);
            target.z = newCurrentItem.transform.position.z;
            newCurrentItem.velocity = newCurrentItem.transform.TransformDirection(target - transform.position);
            Destroy(newCurrentItem.gameObject, 3.0f);
        }

    }

    public void PlayerInput()
    {
        // PLAYER MOVEMENT
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
        else
        { // Infinite movement if this else isnt here....
            moveInput = new Vector2(hAxis, vAxis);
        }
        moveVelocity = moveInput.normalized * playerSpeed;


        // ITEM INPUT
        if (ItemOption() == 1) // Laser
        {
            currentItem = Items[ItemOption() - 1];
        }
        else if (ItemOption() == 2) // Tennis
        {
            currentItem = Items[ItemOption() - 1];
        }
        else if (ItemOption() == 3) // Booster
        {
            Booster();
            Invoke("NormalSpeed", 1f);
        }
    }

    private void NormalSpeed()
    {
        playerSpeed = 10;
    }

    private void Booster()
    {
        playerSpeed = 20;
    }

    public int ItemOption()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return 2;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    
    public void MovePlayer()
    {
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D c) 
    {
		Debug.Log(c.tag);
        BoxCollider2D collider = c.GetComponent<BoxCollider2D>();
        if (collider.tag == "Door") {
            int houseNumber = Int32.Parse(collider.name.Substring(4,1));
            //gameMaster.cur_game_state = GameMaster.game_state_start_loading_level;
            gameMaster.SetCurrentGameState("load");
            gameMaster.EnterHouse(houseNumber);
        }
	}

    void OnTriggerStay2D(Collider2D c)
	{
        if (c.tag == "SpecialItem" && Input.GetKey(KeyCode.C))
		{
			// TODO: save the item under the player
			gameMaster.SetCurrentGameState("load");
			gameMaster.EnterStreet();
		}
	}

}
