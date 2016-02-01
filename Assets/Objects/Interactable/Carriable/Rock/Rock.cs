//Michael Schilling
//CSci 448
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
    void FixedUpdate()
    {
        if(isBeingCarried)
        {
            rockBoddy.velocity = new Vector3(0, 0);
        }

    }

}
