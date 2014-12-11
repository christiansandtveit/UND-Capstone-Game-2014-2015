//Christian Oliver Sandtveit
//CSci 492
/* Script written by Christian Sandtveit. The script allows an object to move on walls in a square pattern. The
   script was written with the spider queen object in mind, but it can also be used on other objects. The length 
   of movement is randomized such that all spiders added will have some variability in how they move. */

using UnityEngine;
using System.Collections;

public class MoveSpider : MonoBehaviour {

    //Declare and initialize variables
    int i = 0; //bariable i is used to implement the intervals
    float velocity = 0.005f; //Speed the spider is moving in
    int interval;
    float orientationChange = 90; //Since the psider is moving in a square, rotate 90 degrees when changing directions
    float yAngle;

	// Use this for initialization
	void Start () {
        yAngle = transform.eulerAngles.y; //Get the current roatation on the y axis
        /* Getting a random interval. The interval determines how far the object will move in one direction
           before changine directions */
        interval = Random.Range(100, 300);
	}
	
	// Update is called once per frame
	void Update () {
        /* Depending on the degree the spider is rotated in, the movement and rotations will vary. The if statements checks the default
           rotation, and then starts the script accordingly. As of now, the spider must be placed in a manner where its rotation on the y axis 
           is either 0, 90. 180 or 270 degrees. In other words, on all walls in a room if it have default placement on the axis'. It then uses
           the transform, which all objects has, to correctly rotate the object and move the object along the appropraite axis. 
           transform.eulerAngles changes the orientation of the spider, and transform.position the position of the spider.*/
        if((int)yAngle == 90)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if (i == interval - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(0, 0, velocity);
                if (i == (interval * 2) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 2);
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if (i == (interval * 3) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 3);
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(0, 0, -velocity);
                if (i == (interval * 4) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 4);
                    i = 0;
                }
            }
        }
        else if ((int)yAngle == 270)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if (i == interval - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 3);
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(0, 0, velocity);
                if (i == (interval * 2) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 2);
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if (i == (interval * 3) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 1);
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(0, 0, -velocity);
                if (i == (interval * 4) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 4);
                    i = 0;
                }
            }
        }
        else if ((int)yAngle == 0)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if (i == interval - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 3);
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(velocity, 0, 0);
                if (i == (interval * 2) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 2);
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if (i == (interval * 3) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 1);
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(-velocity, 0, 0);
                if (i == (interval * 4) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 4);
                    i = 0;
                }
            }
        }
        else if ((int)yAngle == 180)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if (i == interval - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 1);
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(velocity, 0, 0);
                if (i == (interval * 2) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 2);
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if (i == (interval * 3) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 3);
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(-velocity, 0, 0);
                if (i == (interval * 4) - 1)
                {
                    transform.eulerAngles = new Vector3(0, yAngle, orientationChange * 4);
                    i = 0;
                }
            }
        }

        i++; 
	}
}
