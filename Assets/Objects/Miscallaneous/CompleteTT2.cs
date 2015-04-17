//Christian Oliver Sandtveit
//Script which will create a trigger which will determine when the player completes
//the second timetrial puzzle

using UnityEngine;
using System.Collections;

public class CompleteTT2 : MonoBehaviour {

    //Boolean
    public static bool completedTrial;

    // Use this for initialization
    void Start()
    {
        renderer.enabled = false;
        completedTrial = false;
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player")
        {
            print("COMPLETE");
            completedTrial = true;
            InteractTimeTrialLever.lever2TimeTrialActive = false;
        }
    }
}
