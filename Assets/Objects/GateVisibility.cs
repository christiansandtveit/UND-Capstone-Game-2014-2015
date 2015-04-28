//Christian Oliver Sandtveit
//Script which renders the gate blocking the final door active or ianctive. This depends on whether or
//not all keys has been collected

using UnityEngine;
using System.Collections;

public class GateVisibility : MonoBehaviour {


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        /* If all keys have been collected, set the gate to inactive, disabling rendering and physiscs */
        if (KeyManager.timeKeyCollected == true && KeyManager.teleKeyCollected == true && KeyManager.iceKeyCollected == true)
        {
            gameObject.SetActive(false); 
        }
	}
}
