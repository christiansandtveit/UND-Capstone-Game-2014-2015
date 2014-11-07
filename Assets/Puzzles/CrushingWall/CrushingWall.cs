//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class CrushingWall : Activatable {

    public float totalDistanceToMove = 1.5f;
    public float speed = 0.5f;
    public float startDelay = 1f;

    private Vector3 originalLocation;
    private Vector3 targetLocation;
    private bool isDoneMoving = false;
	// Use this for initialization
	void Start ()
    {
        originalLocation = transform.position;
        targetLocation = originalLocation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.transform.position.z > targetLocation.z)
        {
            float newZ = this.transform.position.z - (speed * Time.deltaTime);
            if(newZ < targetLocation.z)
            {
                this.transform.position = new Vector3(originalLocation.x, originalLocation.y, targetLocation.z);
            }
            else
            {
                this.transform.position = new Vector3(originalLocation.x, originalLocation.y, newZ);
            }
        }
        if(this.transform.position.z <= targetLocation.z)
        {
            isDoneMoving = true;
			audio.Stop ();
        }
	}

    public override void Activate()
    {
        StartCoroutine(StartSlide());
    }

    public override void Deactivate()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (isDoneMoving && other.tag == "Player")
        {
            isDoneMoving = false;
            other.transform.root.GetComponent<Manager>().Kill();
        }
    }

    IEnumerator StartSlide()
    {
		audio.Play ();
        yield return new WaitForSeconds(startDelay);
        targetLocation.z -= totalDistanceToMove;
    }

    public override void Reset() { }
}
