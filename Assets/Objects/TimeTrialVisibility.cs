//Written by Christian Sandtveit
//Script which is used to activate or deactivate objects depending on whether lever1 is active in the timetriallevel scene

/* WORK IN PROGRESS */

using UnityEngine;
using System.Collections;

public class TimeTrialVisibility : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (InteractTimeTrialLever.lever1TimeTrialActive == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
