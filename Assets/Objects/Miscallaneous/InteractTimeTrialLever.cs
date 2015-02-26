﻿//Written by Christian Sandtveit
//Script which is used so that player can interact with the levers in the timetrial level by pressing 'e'

using UnityEngine;
using System.Collections;

public class InteractTimeTrialLever : MonoBehaviour {

    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    public static bool lever1TimeTrialActive; //Static variable, will be accessed in other scripts
    public static bool lever2TimeTrialActive; //Static variable, will be accessed in other scripts

	// Use this for initialization
	void Start () 
    {
	    rayLength = 1.5f;
        lever1TimeTrialActive = false;
        lever2TimeTrialActive = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Ray goes towards the mouse cursor

        if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
        {
            if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
            {
                if (hit.collider.tag == "Lever1") //If the ray hit the object with label Book1
                {
                    lever1TimeTrialActive = true; //Allow OnGUI function to display on screen
                    Invoke("DeactivateLever1", 5.0F); //Invoke the Hide function after 5seconds, makes floating pieces dissapear
                    print("Lever1");
                }
                if (hit.collider.tag == "Lever2") //If the ray hit the object with label Book1
                {
                    lever2TimeTrialActive = true; //Allow OnGUI function to display on screen
                    Invoke("DeactivateLever2", 5.0F); //Invoke the Hide function after 5seconds, makes floating pieces dissapear
                    print("Lever2");
                }
            }
        }
	
	}

    //Functiont to deactivate lever1
    void DeactivateLever1()
    {
        lever1TimeTrialActive = false;
        print("Lever1Deac");
    }

    //Functiont to deactivate lever2
    void DeactivateLever2()
    {
        lever2TimeTrialActive = false;
    }
}
