//Written by Christian Sandtveit
//Script which is used to activate or deactivate objects depending on whether lever1 is active in the timetriallevel scene

using UnityEngine;
using System.Collections;

public class TimeTrialVisibility : MonoBehaviour {

    GameObject g1, g2, g3, g4, g5, g6; //One gameObject per floating rock

	// Use this for initialization
	void Start () {
        /* Find all the objects */
        g1 = transform.Find("Sphere1").gameObject;
        g2 = transform.Find("Sphere2").gameObject;
        g3 = transform.Find("Sphere3").gameObject;
        g4 = transform.Find("Sphere4").gameObject;
        g5 = transform.Find("Sphere5").gameObject;
        g6 = transform.Find("Sphere6").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        /* Activate/deactivate according to the value of lever1TimeTrialActive */
        if (InteractTimeTrialLever.lever1TimeTrialActive == true)
        {
            g1.SetActive(true);
            g2.SetActive(true);
            g3.SetActive(true);
            g4.SetActive(true);
            g5.SetActive(true);
            g6.SetActive(true);
        }
        else
        {
            g1.SetActive(false);
            g2.SetActive(false);
            g3.SetActive(false);
            g4.SetActive(false);
            g5.SetActive(false);
            g6.SetActive(false);
        }
	}
}
