using UnityEngine;
using System.Collections;

public class removeBounce : MonoBehaviour {
	void OnCollisionEnter (Collision col)
	{
		rigidbody.isKinematic = true;

	}
}
