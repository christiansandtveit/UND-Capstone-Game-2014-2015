//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public abstract class Carriable : Interactable {
	public bool isBeingCarried = false;
	SpringJoint joint;

    void Update()
    {
        if (Input.GetButton("Fire1") && (isBeingCarried))
        {
            Destroy(joint);
            isBeingCarried = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 20, ForceMode.Impulse);
        }
    }
	public override void Interact(Transform interactor)
	{
		if (!isBeingCarried)
		{
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			joint = gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedBody = interactor.GetComponent<Rigidbody>();
			joint.anchor = Vector3.zero;
			joint.connectedAnchor = Vector3.zero;
			joint.spring = 10000;
			joint.damper = 0;
			joint.maxDistance = 0;
			isBeingCarried = true;
			GetComponent<Collider>().isTrigger = true;
		}
		else
		{
			Destroy(joint);
			isBeingCarried = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GetComponent<Collider>().isTrigger = false;
		}
	}
}
