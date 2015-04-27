using UnityEngine;
using System.Collections;

public class GateVisibility : MonoBehaviour {


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (KeyManager.timeKeyCollected == true && KeyManager.teleKeyCollected == true && KeyManager.iceKeyCollected == true)
        {
            gameObject.SetActive(false); 
        }
	}
}
