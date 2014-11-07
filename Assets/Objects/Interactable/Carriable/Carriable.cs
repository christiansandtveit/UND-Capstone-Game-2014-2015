//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public abstract class Carriable : Interactable {
	public bool isBeingCarried = false;
	SpringJoint joint;

	public override void Interact(Transform interactor)
	{
		if (!isBeingCarried)
		{
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			joint = gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedBody = interactor.rigidbody;
			joint.anchor = Vector3.zero;
			joint.connectedAnchor = Vector3.zero;
			joint.spring = 10000;
			joint.damper = 0;
			joint.maxDistance = 0;
			isBeingCarried = true;
			collider.isTrigger = true;
		}
		else
		{
			Destroy(joint);
			isBeingCarried = false;
			rigidbody.constraints = RigidbodyConstraints.None;
			collider.isTrigger = false;
		}
	}
}
