//made by matthew nelson
using UnityEngine;
using System.Collections;

public class triggerField : MonoBehaviour {
    public Activatable[] thingsToActivate;//list of things to activate when the field is activated
    public Activatable[] thingsToDeactivate;//list of thngs to deactivate when the field is activated
    public bool isOneTimeTrigger = false;//if this field can only be triggered once   
    private bool isTriggered = false;//if the field has been triggered
    private short triggeringObjectCount;//how many times the field has been triggered used for debugging 


    private void Trigger()
    {
        triggeringObjectCount++;
        Debug.Log("trigger field" + triggeringObjectCount);
        if (!isTriggered)
        {
            for (int i = 0; i < thingsToActivate.Length; i++)
            {
                if (thingsToActivate[i] != null)
                {
                    thingsToActivate[i].Activate();
                }
            }
            for (int i = 0; i < thingsToDeactivate.Length; i++)
            {
                if (thingsToDeactivate[i] != null)
                {
                    thingsToDeactivate[i].Deactivate();
                }
            }
        }
        if (isOneTimeTrigger)
        {
            isTriggered = true;
        }
    }

    void Start()
    {

    }

    

    void OnCollisionEnter(Collision other)
    {
        //Trigger();
    }

    void OnTriggerEnter(Collider other)
    {
        Trigger();
    }



}
