using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
    public Transform exit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = exit.transform.position;
    }
}
