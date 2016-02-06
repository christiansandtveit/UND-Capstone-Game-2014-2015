using UnityEngine;
using System.Collections;
public class triggerField : MonoBehaviour {
    public Activatable[] thingsToActivate;
    public Activatable[] thingsToDeactivate;
    public bool isOneTimeTrigger = false;   
    private bool isTriggered = false;      
    private short triggeringObjectCount;


    private void Trigger()
    {
        triggeringObjectCount++;
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
        Trigger();
    }

    void OnTriggerEnter(Collider other)
    {
        Trigger();
    }



}
