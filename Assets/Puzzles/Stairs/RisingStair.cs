//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class RisingStair : Activatable
{
    public StairPuzzleSwitch[] switches;
    private bool isActivated = false;
    private Vector3 originalLoc;
    public float heightToRaise = 2f;
    public float slideSpeed = 2f;
    private Vector3 targetLocation;

    private int ActivationCount
    {
        get
        {
            int c = 0;
            foreach (StairPuzzleSwitch ps in switches)
            {
                if (ps.isTriggered)
                {
                    c++;
                }
            }
            return c;
        }
    }

    void Start()
    {
        originalLoc = this.transform.position;
        targetLocation = originalLoc;
    }

    public override void Activate()
    {
		GetComponent<AudioSource>().Stop ();
        targetLocation.y = originalLoc.y + heightToRaise;
        isActivated = true;
		GetComponent<AudioSource>().Play ();
    }

    public override void Deactivate()
    {
		GetComponent<AudioSource>().Stop ();
        targetLocation.y = originalLoc.y;
        isActivated = false;
		GetComponent<AudioSource>().Play ();

    }


    void Update()
    {
        if (ActivationCount % 2 == 0 && isActivated)
        {
            Deactivate();
        }
        else if (ActivationCount % 2 == 1 && !isActivated)
        {
            Activate();
        }
        AdjustHeight();
		if (this.transform.position.y == targetLocation.y || this.transform.position.y == originalLoc.y)
		{
			GetComponent<AudioSource>().Stop ();
		}
    }

    private void AdjustHeight()
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

        // Move down
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
    }

    public override void Reset() { }
}
