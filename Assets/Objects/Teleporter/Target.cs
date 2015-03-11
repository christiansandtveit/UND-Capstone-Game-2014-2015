using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Target : AbstractResetable
{
    public Activatable[] thingsToActivate;
    public bool isOneTimeTrigger = false; 	// true means that the switch can be triggered on, then off, then on...
    private bool isTriggered = false; 		// is the switch currently triggered?
    private short triggeringObjectCount;	// allows a player to walk on a switch while a rock is on it without 'UnTriggering'

    private Vector3 targetLocation;
    private Vector3 originalLoc;
    public float heightToLower = 0.05f;
    public float slideSpeed = 2f;
    private guiScore scoreKeeper;
    public int value = 10000;
    private Vector3 current;

 

    private void Trigger()
    {
        triggeringObjectCount++;
        if (!isTriggered)
        {
            for (int i = 0; i < thingsToActivate.Length; i++)
            {
                if (thingsToActivate[i] != null)
                {
                    thingsToActivate[i].Activate();
                }
            }
            targetLocation.z = originalLoc.z - heightToLower;
            audio.Play();
        }
        isTriggered = true;
    }

    private void UnTrigger()
    {
        triggeringObjectCount--;
        // UnTrigger... great word.
        if (!isOneTimeTrigger && triggeringObjectCount <= 0)
        {
            for (int i = 0; i < thingsToActivate.Length; i++)
            {
                thingsToActivate[i].Deactivate();
            }
            isTriggered = false;
            targetLocation.z = originalLoc.z;
        }
    }

    void Start()
    {
        scoreKeeper = GameObject.FindObjectOfType<guiScore>();
        originalLoc = this.transform.position;
        targetLocation = originalLoc;
    }

    void Update()
    {
        // Move up
        if (this.transform.position.z < targetLocation.z)
        {
            float newZ = this.transform.position.z + (slideSpeed * Time.deltaTime);
            if (newZ > targetLocation.z)
            {
                this.transform.position = new Vector3(originalLoc.x, originalLoc.y, targetLocation.z);
            }
            else
            {
                this.transform.position = new Vector3(originalLoc.x, originalLoc.y, newZ);
            }
        }

        // Move down
        else if (this.transform.position.z > targetLocation.z)
        {
            float newZ = this.transform.position.z - (slideSpeed * Time.deltaTime);
            if (newZ < targetLocation.z)
            {
                this.transform.position = new Vector3(originalLoc.x, originalLoc.y, targetLocation.z);
            }
            else
            {
                this.transform.position = new Vector3(originalLoc.x, originalLoc.y, newZ);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        scoreKeeper.Increase(value);
        Trigger();
    }


    void OnTriggerEnter(Collider other)
    {
        Trigger();
    }

    void OnCollisionExit(Collision other)
    {
        UnTrigger();
    }

    void OnTriggerExit(Collider other)
    {
        UnTrigger();
    }

    public override void Reset()
    {
        isTriggered = false;
    }

}
