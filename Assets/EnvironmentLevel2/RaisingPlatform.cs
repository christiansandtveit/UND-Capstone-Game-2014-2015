//Alex Lewis
//CSci 448
using UnityEngine;
using System.Collections;

public class RaisingPlatform : Activatable {
	
	public float fallTimeDelay = 1.0f;
	private float finalHeight;
	private Vector3 originalLoc;

	public float heightToRaise = 5f;
	public float slideSpeed = 2f;
	private Vector3 targetLocation;

	
	void Start()
	{
		originalLoc = this.transform.position;
		targetLocation = originalLoc;
	}

	public override void Activate ()
	{
		GetComponent<AudioSource>().Stop ();
		targetLocation.y = originalLoc.y + heightToRaise;
		GetComponent<AudioSource>().Play ();
	}
	public override void Deactivate ()
	{
	}
	void OnTriggerEnter()
	{
		print ("I'm starting to fall!");
		StartCoroutine("Fall");
	}
	
	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallTimeDelay);
		targetLocation.y = originalLoc.y;
	}
	void Update()
	{
		// Move up
		if (this.transform.position.y < targetLocation.y)
		{
			float newY = this.transform.position.y + (slideSpeed * Time.deltaTime);
			if (newY > targetLocation.y)
			{
				this.transform.position = new Vector3(originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3(originalLoc.x, newY, originalLoc.z);
			}
		}
		else if (this.transform.position.y > targetLocation.y)
		{
			float newY = this.transform.position.y - (slideSpeed * Time.deltaTime);
			if (newY < targetLocation.y)
			{
				this.transform.position = new Vector3(originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3(originalLoc.x, newY, originalLoc.z);
			}
		}
		if (this.transform.position.y == targetLocation.y || this.transform.position.y == originalLoc.y)
		{
			GetComponent<AudioSource>().Stop ();
		}
	}
	public override void Reset() 
	{
	}
}
