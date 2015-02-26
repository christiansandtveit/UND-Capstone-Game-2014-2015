//Written by Christian Sandtveit
//Script which is used to play clock sound when lever1 is activated in the timetriallevel

using UnityEngine;
using System.Collections;

public class LeverSound : MonoBehaviour {

    bool playing; //variable to indicate that sound si already playing

	// Use this for initialization
	void Start () {
	    playing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (InteractTimeTrialLever.lever1TimeTrialActive == true && playing == false)
        {
            audio.Play();
            playing = true;
        }
        else if (InteractTimeTrialLever.lever1TimeTrialActive == false && playing == true)
        {
            audio.Stop();
            playing = false;
        }
	}
}
