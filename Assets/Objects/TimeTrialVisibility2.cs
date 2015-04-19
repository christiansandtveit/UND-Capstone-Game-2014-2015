using UnityEngine;
using System.Collections;

public class TimeTrialVisibility2 : MonoBehaviour {
    GameObject b1, b2;

	// Use this for initialization
	void Start () {
        /* Find all the objects */
        b1 = transform.Find("Block1").gameObject;
        b2 = transform.Find("Block2").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        /* WORK IN PROGRESS */
        if (InteractTimeTrialLever.lever2TimeTrialActive == true)
        {
            b1.SetActive(false);
            b2.SetActive(false);
        }
        else
        {
            b1.SetActive(true);
            b2.SetActive(true);
        }
	}
}
