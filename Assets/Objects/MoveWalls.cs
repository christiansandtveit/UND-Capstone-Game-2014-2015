//Christian Oliver Sandtveit
//Script used to move the walls towards eachother in the 2nd puzzle in the timetrial level

using UnityEngine;
using System.Collections;

public class MoveWalls : MonoBehaviour {

    private Vector3 originalPosition;
    private float velocity;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        velocity = 0.45f;
	}
	
	// Update is called once per frame
	void Update () {
        if (InteractTimeTrialLever.lever2TimeTrialActive == true && CompleteTT2.completedTrial == false)
        {
            if (gameObject.name == "Left")
            {
                transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0);
            }
            else if (gameObject.name == "Right")
            {
                transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
            }
        }
        else if (InteractTimeTrialLever.lever2TimeTrialActive == false && CompleteTT2.completedTrial == false)
        {
            transform.position = originalPosition;
        }
	}
}
