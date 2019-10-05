using UnityEngine;

public class Animal : MovingObject
{
	public Transform player;
    public bool moving = true;
	public Sprite sprite; // for Animal's child classes
    float pushMagnitude = 1000f;

    protected override void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
        //base.speed = Random.value * 4f;
        base.speed = 3f;

        base.Start();
    }

    public void FixedUpdate()
	{
        if (moving)
        {
            Move();
        }
	}

    protected override void Move()
    {
		transform.LookAt(player.transform);
		transform.position +=
            (new Vector3(transform.forward.x, transform.forward.y, 0f)) * speed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
        //Debug.Log(transform.tag);
        //Debug.Log(transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            // TODO: Stage over. Restart
        }
        else if (collider.tag == "Enemy")
        {
            // If other animals, push each other off, instead of getting on top of each other
            ///*
            moving = false;
            Vector2 pushOffDirection = (transform.position - collider.transform.position).normalized;
            Debug.Log(transform.position);
            Debug.Log(collider.transform.position);
            Debug.Log(pushOffDirection);
            base.rb.AddForce(pushOffDirection * pushMagnitude);
            collider.attachedRigidbody.AddForce(pushOffDirection * pushMagnitude);
            //moving = true;
            //*/
        }
    }

    //protected override void OnCollisionEnter(Collision collision)
}
