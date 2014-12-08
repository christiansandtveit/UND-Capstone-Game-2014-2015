//Christian Oliver Sandtveit
//CSci 492

using UnityEngine;
using System.Collections;

public class MovingBug : MonoBehaviour {

    float orientation;
    float velocity = 0.01f;
    int i;
    CharacterController ai;
    int maxAngleChange = 30;
    private Vector3 direction = Vector3.zero;
    int num;

	// Initialize
	void Start () {
        ai = GetComponent<CharacterController>();
        orientation = Random.Range(0, 360); // Random orientation to start with
        transform.eulerAngles = new Vector3(0, orientation, 0);
	}
	
	// Update is called once per frame
	void Update () {
        num = Random.Range(1, 100);
        if (num == 7)
        {
            orientation = Random.Range(orientation - maxAngleChange, orientation + maxAngleChange);
            transform.eulerAngles = new Vector3(0, orientation, 0);
        }


        direction = new Vector3(0, 0, velocity);
        direction = transform.TransformDirection(direction);
        ai.Move(direction);
	}

    void OnCollisionEnter(UnityEngine.Collision col)
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        velocity = -velocity;
    }

}
