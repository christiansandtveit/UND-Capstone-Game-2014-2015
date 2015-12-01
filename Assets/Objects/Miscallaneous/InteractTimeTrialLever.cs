//Written by Christian Sandtveit
//Script which is used so that player can interact with the levers in the timetrial level by pressing 'e'

using UnityEngine;
using System.Collections;

public class InteractTimeTrialLever : MonoBehaviour
{

    float lever1ActiveLength;
    float lever2ActiveLength;
    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    public static bool lever1TimeTrialActive; //Static variable, will be accessed in other scripts
    public static bool lever2TimeTrialActive; //Static variable, will be accessed in other scripts
    GameObject lever1, lever2;


    // Use this for initialization
    void Start()
    {
        lever1 = GameObject.FindWithTag("CylinderLever1");
        lever2 = GameObject.FindWithTag("CylinderLever2");
        lever1ActiveLength = 10.0f;
        lever2ActiveLength = 20.0f;
        rayLength = 1.5f;
        lever1TimeTrialActive = false;
        lever2TimeTrialActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y)); //Ray goes towards middle of screen

        if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
        {
            if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
            {
                if (hit.collider.tag == "Lever1") //If the ray hit the object with label Lever1
                {
                    lever1TimeTrialActive = true; //set boolean to true
                    lever1.GetComponent<Animation>().Play("leverPull"); //Play animation
                    Invoke("DeactivateLever1", lever1ActiveLength); //Invoke the Hide function after 5seconds, makes floating pieces dissapear
                    print("Lever1");
                }
                if (hit.collider.tag == "Lever2") //If the ray hit the object with label Lever2
                {
                    lever2TimeTrialActive = true; //set boolean to true
                    lever2.GetComponent<Animation>().Play("leverPull2"); //Play animation
                    Invoke("DeactivateLever2", lever2ActiveLength); //Invoke the Hide function after 5seconds, makes floating pieces dissapear
                    print("Lever2");
                }
            }
        }

        if (DeathManagerTimeTrial.dead == true && lever1TimeTrialActive == true)
        {
            lever1TimeTrialActive = false;
            CancelInvoke("DeactivateLever1");
        }
        if (DeathManagerTimeTrial.dead == true && lever2TimeTrialActive == true)
        {
            lever2TimeTrialActive = false;
            CancelInvoke("DeactivateLever2");
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
        print("Lever2Deac");
    }


}
