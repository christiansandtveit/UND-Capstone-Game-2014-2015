using UnityEngine;
using System.Collections;
//Erik Sommer
public class pushBox : MonoBehaviour {
	
	public float rayLength; //Length of ray, i.e. how far away player can interact with box
	public float pushPower = 4F;
	
	// Use this for initialization
	void Start () {
		rayLength = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit; //Used to query what the ray hit
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		
		Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y)); //Ray goes towards middle of screen
		
		if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
		{
			if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
			{
				if (hit.collider.tag == "right") //If the ray hit the object with label box
				{
					Rigidbody body = hit.collider.attachedRigidbody;//get object hit by ray
					body.GetComponent<Rigidbody>().isKinematic = false;
					Vector3 pushDir = new Vector3(0,0,1);
					body.velocity =  pushDir* pushPower; //apply velocity to object
				}
				if (hit.collider.tag == "left") //If the ray hit the object with label box
				{
					Rigidbody body = hit.collider.attachedRigidbody;//get object hit by ray
					body.GetComponent<Rigidbody>().isKinematic = false;
					Vector3 pushDir = new Vector3(0,0,-1);
					body.velocity =  pushDir* pushPower; //apply velocity to object
				}
				if (hit.collider.tag == "up") //If the ray hit the object with label box
				{
					Rigidbody body = hit.collider.attachedRigidbody;//get object hit by ray
					body.GetComponent<Rigidbody>().isKinematic = false;
					Vector3 pushDir = new Vector3(-1,0,0);
					body.velocity =  pushDir* pushPower; //apply velocity to object
				}
				if (hit.collider.tag == "down") //If the ray hit the object with label box
				{
					Rigidbody body = hit.collider.attachedRigidbody;//get object hit by ray
					body.GetComponent<Rigidbody>().isKinematic = false;
					Vector3 pushDir = new Vector3(1,0,0);
					body.velocity =  pushDir* pushPower; //apply velocity to object
				}
			}
		}
		
	}
}