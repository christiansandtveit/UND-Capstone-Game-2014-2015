//Christian Oliver Sandtveit
//CSci 492

using UnityEngine;
using System.Collections;

public class MoveSpider : MonoBehaviour {

    int i = 0;
    float velocity = 0.005f;
    int interval;
    float orientationChange = 90;
    float yAngle;

	// Use this for initialization
	void Start () {
        yAngle = transform.eulerAngles.y;
        interval = Random.Range(100, 300);
	}
	
	// Update is called once per frame
	void Update () {
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
