//Michael Schilling
//CSci 448
//edited by Matthew Nelson to make the object not stay still when picked up
using UnityEngine;
using System.Collections;

public class Rock : Carriable {
    public Rigidbody rockBoddy;
    void Start()
    {
        rockBoddy = GetComponent<Rigidbody>();
    }
	void OnCollisionEnter(Collision col) {
		if (!GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().Play ();
		}
    }
    /**
    This function resets the velocity of the rock to zero if the rock is being carried by the player
        by Matthew Nelson
    */
    void FixedUpdate()
    {
        if(isBeingCarried)
        {
            rockBoddy.velocity = new Vector3(0, 0);
        }

    }

}
