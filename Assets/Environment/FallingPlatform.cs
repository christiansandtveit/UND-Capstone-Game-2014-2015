//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class FallingPlatform : AbstractResetable {

	public float fallTimeDelay = 2.0f;
	public float fallDistance = 150.0f;
	private float finalHeight;
	private Vector3 originalLoc;

	void Start()
	{
		originalLoc = this.transform.position;
		finalHeight = transform.position.y - fallDistance;
	}

	void OnTriggerEnter(Collider Other)
	{
		if (Other.tag == "Player") 
		{
			if (!audio.isPlaying) {
					audio.Play ();
			}

			print ("I'm starting to fall!");
			StartCoroutine ("Fall");
		}

	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallTimeDelay);
		rigidbody.isKinematic = false;
		rigidbody.useGravity = true;
		while(transform.position.y > finalHeight)
		{
			yield return null;
		}
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
	}

	public override void Reset()
	{
		this.transform.position = originalLoc;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
	}
}
