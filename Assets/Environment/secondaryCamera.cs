//Alex Lewis
//CSci 448
using UnityEngine;
using System.Collections;

public class secondaryCamera : Activatable {

	public float timeDelay = 3.0f;
	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Activate ()
	{
		this.gameObject.SetActive (true);
		StartCoroutine("Fall");
	}
	
	public override void Deactivate ()
	{
		this.gameObject.SetActive (false);
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(timeDelay);
		Deactivate ();

	}

	public override void Reset() { }
}
