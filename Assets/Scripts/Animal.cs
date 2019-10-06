using UnityEngine;

public class Animal : MovingObject
{
	private Transform player;
	public Sprite sprite; // for Animal's child classes
    public GameMaster gameMaster;

    protected override void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
        gameMaster = FindObjectsOfType<GameMaster>()[0];
        //base.speed = Random.value * 4f;
        base.speed = 3f;

        base.Start();
    }

    public void FixedUpdate()
	{
        if (!gameMaster.doingSetup)
		{
			Move();
		}
	}

    protected override void Move()
    {
		transform.LookAt(player.transform);

		Vector3 direction = new Vector3(transform.forward.x, transform.forward.y, 0f);
		direction.x *= Random.Range(0.5f, 2f);
		direction.y *= Random.Range(0.5f, 2f);

		transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
			gameMaster.UpdateCanvas("Street", false, -1);
			gameMaster.SetCurrentGameState("load");
            gameMaster.EnterStreet();
        }
    }

    //protected override void OnCollisionEnter(Collision collision)
}
