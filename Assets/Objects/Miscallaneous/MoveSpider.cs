//Christian Oliver Sandtveit
//CSci 492
/* Script written by Christian Sandtveit. The script allows an object to move on walls in a square pattern. The
   script was written with the spider queen object in mind, but it can also be used on other objects. The length 
   of movement is randomized such that all spiders added will have some variability in how they move. */
   /**Edited By Matthew Nelson to have smooth turns*/

using UnityEngine;
using System.Collections;

public class MoveSpider : MonoBehaviour {

    //Declare and initialize variables
    float i = 0; //variable i is used to implement the intervals
    public float velocity = 0.005f; //Speed the spider is moving in
    int interval;
    float orientationChange = 0; //an verible of the current rotation amount 
    public float orientationIncremant = 5;//amount to turn by
    public int randomLow = 100; //the low end of the size of the randonly sized box the spider goes around
    public int randomHigh = 300; //the high end of the size of the randonly sized box the spider goes around
    float iIncrement;
    float yAngle;

	// Use this for initialization
	void Start () {
        yAngle = transform.eulerAngles.y; //Get the current roatation on the y axis
        /* Getting a random interval. The interval determines how far the object will move in one direction
           before changine directions */
        if(randomLow >= randomHigh)//set the random number to 1-random high if low is bigger or equal to high
        {
            randomLow = randomHigh - 1;
        }
        interval = Random.Range(randomLow, randomHigh);
        iIncrement = (velocity * 1000) / 5;
        if(iIncrement > 1)
        {
            iIncrement = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //this if handles the spider if the spider had a starting angle between 45 and 135
        if ((int)yAngle >= 45  && (int)yAngle < 135)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if ((int)i == interval - 1)//if it is time to start turning
                {
                    orientationChange = orientationChange + orientationIncremant;//increase the angle when turning
                    if(orientationChange < 90) //if turn is complete yet
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else //end turning motion
                    {
                        orientationChange = 90;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }
                    
                }
                else//more forward if not turnning 
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(0, 0, velocity);
                if ((int)i == (interval * 2) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 180)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 180;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if ((int)i == (interval * 3) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 270)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 270;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(0, 0, -velocity);
                if ((int)i == (interval * 4) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 360 && orientationIncremant != 0)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 0;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = 0;
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
        }
        //this if handles the spider if the spider had a starting angle between 225 and 315
        else if ((int)yAngle >= 225 && (int)yAngle < 315)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if ((int)i == (interval * 1) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -90)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -90;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(0, 0,velocity);
                if ((int)i == (interval * 2) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -180)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -180;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if ((int)i == (interval * 3) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -270)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -270;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(0, 0, -velocity);
                if ((int)i == (interval * 4) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -360 && orientationChange != 0)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 0;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = 0;
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
        }
        //this if handles the spider if the spider had a starting angle is greater then 315 or less then 45
        else if ((int)yAngle >= 315 || (int)yAngle < 45)
        {
            if (i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if ((int)i == (interval * 1) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -90)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -90;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(velocity, 0,0);
                if ((int)i == (interval * 2) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -180)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -180;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if ((int)i == (interval * 3) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -270)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = -270;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3(-velocity, 0, 0);
                if ((int)i == (interval * 4) - 1)
                {
                    orientationChange = orientationChange - orientationIncremant;
                    if (orientationChange > -360 && orientationChange != 0)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 0;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = 0;
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
        }
        //this if handles the spider if the spider had a starting angle between 135 and 225
        else if((int)yAngle >= 135 && (int)yAngle < 225)
        {
            if ((int)i >= 0 && i < interval)
            {
                transform.position += new Vector3(0, velocity, 0);
                if ((int)i == (interval * 1) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 90)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 90;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval && i < interval * 2)
            {
                transform.position += new Vector3(velocity, 0,0);
                if ((int)i == (interval * 2) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 180)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 180;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 2 && i < interval * 3)
            {
                transform.position += new Vector3(0, -velocity, 0);
                if ((int)i == (interval * 3) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 270)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 270;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
            else if (i >= interval * 3 && i < interval * 4)
            {
                transform.position += new Vector3( -velocity, 0,0);
                if ((int)i == (interval * 4) - 1)
                {
                    orientationChange = orientationChange + orientationIncremant;
                    if (orientationChange < 360 && orientationChange != 0)
                    {
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                    }
                    else
                    {
                        orientationChange = 0;
                        transform.eulerAngles = new Vector3(0, yAngle, orientationChange);
                        i = 0;
                        i = i + iIncrement;
                    }

                }
                else
                {
                    i = i + iIncrement;
                }
            }
        }

         
	}
}
