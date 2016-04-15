using UnityEngine;
using System.Collections;

public class removeBounce : MonoBehaviour {
	void OnCollisionEnter (Collision col)
	{
		GetComponent<Rigidbody>().isKinematic = true;

	}
}
