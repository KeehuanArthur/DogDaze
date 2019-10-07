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

    [Header("Sounds")]
    public GameObject akMusicPlayer;
    public AK.Wwise.Event waterSpray;
    public AK.Wwise.Event tailWag;
    public AK.Wwise.Event soccerBall;
    public AK.Wwise.Event roombaSound;
    public AK.Wwise.Switch Junkyard;
    public AK.Wwise.Switch Street;
    public AK.Wwise.Switch room_1;
    public AK.Wwise.Switch room_2;


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
        if (!gameMaster.doingSetup)
	    {
		    MovePlayer();
		    Fire();
		}
	}
	private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && currentItem == Items[0])   // 
        {
            tailWag.Post(gameObject);//play sound
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D newCurrentItem;
            newCurrentItem = Instantiate(currentItem, transform.position, Quaternion.identity);
            target.z = newCurrentItem.transform.position.z;
            newCurrentItem.transform.position = target;
            Destroy(newCurrentItem.gameObject, 3.0f);
        }

        if (Input.GetMouseButtonDown(0) && currentItem == Items[1])   // Useful for tennisball
        {

            waterSpray.Post(gameObject); //play sound
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
        moveInput = new Vector2(hAxis, vAxis);
       
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

    void OnTriggerStay2D(Collider2D c)
	{
        if (c.tag == "SpecialItem" && Input.GetKey(KeyCode.C))
		{
			// TODO: save the item under the player
			gameMaster.UpdateCanvas("Street", true, -1);
            gameMaster.SetCurrentGameState(GameMaster.game_state_start_loading_level);
            Street.SetValue(akMusicPlayer);//music changes
            gameMaster.EnterScene("street");
        }
	}
}

