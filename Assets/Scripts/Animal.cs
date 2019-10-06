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
        Move();
	}

    protected override void Move()
    {
		transform.LookAt(player.transform);

		Vector3 direction = new Vector3(transform.forward.x, transform.forward.y, 0f);
		direction.x *= Random.Range(0.5f, 2f);
		direction.y *= Random.Range(0.5f, 2f);

		transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
        //Debug.Log(transform.tag);
        //Debug.Log(transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameMaster.SetCurrentGameState("load");
            gameMaster.EnterStreet();
        }
        else if (collision.collider.tag == "Enemy")
        {
            // If other animals, push each other off, instead of getting on top of each other
            /*
            Vector2 pushOffDirection = (transform.position - collider.transform.position).normalized;
            Debug.Log(transform.position);
            Debug.Log(collider.transform.position);
            Debug.Log(pushOffDirection);
            base.rb.AddForce(pushOffDirection * pushMagnitude);
            collider.attachedRigidbody.AddForce(pushOffDirection * pushMagnitude);
            */
        }
    }

    //protected override void OnCollisionEnter(Collision collision)
}
