<<<<<<< HEAD
<<<<<<< HEAD
﻿using UnityEngine;

public class Animal : MovingObject
=======
﻿using UnityEngine;

public class Animal : MovingObject
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
=======
﻿using UnityEngine;

public class Animal : MovingObject
>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
{
	private Transform player;
	public Sprite sprite; // for Animal's child classes
<<<<<<< HEAD
    float pushMagnitude = 1000f;
<<<<<<< HEAD

    protected override void Start()
=======

    protected override void Start()
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
=======
    public GameMaster gameMaster;

    protected override void Start()
>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
    {
		player = GameObject.FindWithTag("Player").transform;
        gameMaster = FindObjectsOfType<GameMaster>()[0];
        //base.speed = Random.value * 4f;
        base.speed = 3f;

        base.Start();
<<<<<<< HEAD
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
=======
    }

    public void FixedUpdate()
	{
        if (!gameMaster.doingSetup)
		{
			Move();
		}
	}

>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
    protected override void Move()
    {
		transform.LookAt(player.transform);

		Vector3 direction = new Vector3(transform.forward.x, transform.forward.y, 0f);
		direction.x *= Random.Range(0.5f, 2f);
		direction.y *= Random.Range(0.5f, 2f);

		transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
<<<<<<< HEAD
        //Debug.Log(transform.tag);
        //Debug.Log(transform.position);
<<<<<<< HEAD
    }

=======
    }

>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
    void OnTriggerEnter2D(Collider2D collider)
=======
    }

    void OnCollisionEnter2D(Collision2D collision)
>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
    {
        if (collision.collider.tag == "Player")
        {
			gameMaster.UpdateCanvas("Street", false, -1);
			gameMaster.SetCurrentGameState("load");
            gameMaster.EnterStreet();
        }
<<<<<<< HEAD
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
=======
>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
    }

    //protected override void OnCollisionEnter(Collision collision)
}
<<<<<<< HEAD
>>>>>>> 72819a0f579cd6391dcf90477d0a530b3d776385
=======
>>>>>>> c3a1e0f639fcc0c50b9947e79dab30dfa17b5089
