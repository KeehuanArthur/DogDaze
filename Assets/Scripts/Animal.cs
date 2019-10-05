<<<<<<< HEAD
﻿using UnityEngine;

public class Animal : MovingObject
=======
﻿using UnityEngine;

public class Animal : MovingObject
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
{
	public Transform player;
    public bool moving = true;
	public Sprite sprite; // for Animal's child classes
    float pushMagnitude = 1000f;
<<<<<<< HEAD

    protected override void Start()
=======

    protected override void Start()
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
    {
		player = GameObject.FindWithTag("Player").transform;
        //base.speed = Random.value * 4f;
        base.speed = 3f;

        base.Start();
<<<<<<< HEAD
    }

=======
    }

>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
    public void FixedUpdate()
	{
        if (moving)
        {
            Move();
        }
<<<<<<< HEAD
	}

=======
	}

>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
    protected override void Move()
    {
		transform.LookAt(player.transform);
		transform.position +=
            (new Vector3(transform.forward.x, transform.forward.y, 0f)) * speed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
        //Debug.Log(transform.tag);
        //Debug.Log(transform.position);
<<<<<<< HEAD
    }

=======
    }

>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
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
<<<<<<< HEAD
    }

    //protected override void OnCollisionEnter(Collision collision)
}
=======
    }

    //protected override void OnCollisionEnter(Collision collision)
}
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
