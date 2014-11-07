//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class SlidingDoor : Activatable {

	private Vector3 originalLoc;
	public float heightToRaise = 2f;
	public float slideSpeed = 2f;
	private Vector3 targetLocation;

	void Start()
	{
		originalLoc = this.transform.position;
		targetLocation = originalLoc;
	}

	public override void Activate ()
	{
		audio.Play ();
		targetLocation.y = originalLoc.y + heightToRaise;
	}

	public override void Deactivate ()
	{
		audio.Play ();
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
				this.transform.position = new Vector3 (originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3 (originalLoc.x, newY, originalLoc.z);
			}
		}

		// Move down
		else if (this.transform.position.y > targetLocation.y)
		{
			float newY = this.transform.position.y - (slideSpeed * Time.deltaTime);
			if (newY < targetLocation.y)
			{
				this.transform.position = new Vector3 (originalLoc.x, targetLocation.y, originalLoc.z);
			}
			else
			{
				this.transform.position = new Vector3 (originalLoc.x, newY, originalLoc.z);
			}
		}

		else
		{	
			audio.Stop ();
		}
	}

    public override void Reset() { }
}
