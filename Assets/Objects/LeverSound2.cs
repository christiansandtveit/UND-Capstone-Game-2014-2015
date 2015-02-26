//Written by Christian Sandtveit
//Script which is used to play clock sound when lever2 is activated in the timetriallevel

using UnityEngine;
using System.Collections;

public class LeverSound2 : MonoBehaviour
{

    bool playing; //variable to indicate that sound is already playing

    // Use this for initialization
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check Lever2 status
        if (InteractTimeTrialLever.lever2TimeTrialActive == true && playing == false)
        {
            audio.Play();
            playing = true;
        }
        else if (InteractTimeTrialLever.lever2TimeTrialActive == false && playing == true)
        {
            audio.Stop();
            playing = false;
        }
    }
}
