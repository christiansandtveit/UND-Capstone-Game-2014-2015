//Christian Oliver Sandtveit
//Script used to set the keys visibility in the hub world according to whether the key hasb een collected or not

using UnityEngine;
using System.Collections;

public class setKeyVisibility : MonoBehaviour {

    GameObject keyTime, keyTele, keyIce; /* varaibles for the gameobjects */

	// Use this for initialization
	void Start () {
        //Find the objects and sett renderer to inactive
        keyTele = transform.Find("hubTeleKey").gameObject;
        keyTele.GetComponent<Renderer>().enabled = false;
        keyTime = transform.Find("hubTimeKey").gameObject;
        keyTime.GetComponent<Renderer>().enabled = false;
        keyIce = transform.Find("hubIceKey").gameObject;
        keyIce.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        /* If the static variable indicates the key has been collected, set renderer to true */
        if (KeyManager.timeKeyCollected == true)
        {
            keyTime.GetComponent<Renderer>().enabled = true;
        }
        if (KeyManager.teleKeyCollected == true)
        {
            keyTele.GetComponent<Renderer>().enabled = true;
        }
        if (KeyManager.iceKeyCollected == true)
        {
            keyIce.GetComponent<Renderer>().enabled = true;
        }
	}
}
