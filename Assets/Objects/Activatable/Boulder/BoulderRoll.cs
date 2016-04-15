//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class BoulderRoll : Activatable {

    private Vector3 initPos;
    private Quaternion initRot;
	public Vector3 angularVelocity = new Vector3(-500f, 0f, 0f);
	public Vector3 initialVelocity = new Vector3(10f, 0f, 0f);
	public float timeDelay = 3f;
	//private bool isActivated = false;

    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }

	public override void Activate ()
	{
        gameObject.AddComponent<DeathOnContact>();
		StartCoroutine("Roll");
		GetComponent<AudioSource>().Play ();
	}

	public override void Deactivate (){}

	IEnumerator Roll()
	{
		GetComponent<Rigidbody>().angularVelocity = this.angularVelocity;
		yield return new WaitForSeconds(timeDelay);
		GetComponent<Rigidbody>().velocity = initialVelocity;
		GetComponent<Rigidbody>().useGravity = true;
		if (GetComponent<Rigidbody>().velocity.magnitude == 0) {
			GetComponent<AudioSource>().Stop ();
		}

	}

    public override void Reset()
    {
        transform.position = initPos;
        transform.rotation = initRot;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
