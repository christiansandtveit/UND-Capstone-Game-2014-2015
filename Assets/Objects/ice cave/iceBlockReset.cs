using UnityEngine;
using System.Collections;

public class iceBlockReset : MonoBehaviour {

	public GameObject iceBlock;

	// Use this for initialization
	void Start () {
		iceBlock = GameObject.Find ("iceBlock");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.R)) 
		{
			iceBlock.transform.position = new Vector3 (37, -2, -6);
		}
	}
}
