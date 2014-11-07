//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        print("trigger");
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Manager>().lastCheckpoint = this;
        }
    }
}
