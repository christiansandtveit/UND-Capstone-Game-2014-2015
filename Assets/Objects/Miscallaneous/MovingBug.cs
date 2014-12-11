//Christian Oliver Sandtveit
//CSci 492
/* This script allows any object which the script has been attached to to move in randomized directions on the
   floor of a level. To function with a object, the object must have a character controller, box collider and
   rigidbody attached to it. The script has some bugs, and will need more work in the future */

using UnityEngine;
using System.Collections;

public class MovingBug : MonoBehaviour {

    //Declare and initialize variables
    float orientation;
    float velocity = 0.01f; //Speed of which the object is moving in
    int i;
    CharacterController ai;
    int maxAngleChange = 30; //Max angle the object can change direction in on a change in direction
    private Vector3 direction = Vector3.zero;
    int num;

	// Initialize
	void Start () {
        ai = GetComponent<CharacterController>(); //grab the characterController of the object
        orientation = Random.Range(0, 360); // Random orientation to start with, clamped between 0-359
        transform.eulerAngles = new Vector3(0, orientation, 0); //Rotate the object in the random starting orientation
	}
	
	// Update is called once per frame
	void Update () {
        num = Random.Range(1, 100); //get a random number between 1-99
        /* if random number equals seven (arbitrary number), the object will change its orientation. This makes the
           movement of the object unpredictable */
        if (num == 7)
        {
            /* new orientation within the maxAngleChange degrees of the old orientation */
            orientation = Random.Range(orientation - (maxAngleChange/2), orientation + (maxAngleChange/2));
            transform.eulerAngles = new Vector3(0, orientation, 0); //rotate the orientation accordingly
        }

        /* Move the bug on the z axis */
        direction = new Vector3(0, 0, velocity);
        direction = transform.TransformDirection(direction); 
        ai.Move(direction);
	}

    /* This will determine if any collisions has occured with any walls. If it has, the object will rotate 180 degrees,
     * and move in the opposite direction of what it was before the collision. In effect, if an object moves into 
       a wall, it should turn all the way around and start moving in the opposite direction */
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        velocity = -velocity;
    }

}
