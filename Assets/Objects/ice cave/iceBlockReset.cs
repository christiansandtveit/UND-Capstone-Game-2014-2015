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
			float x = 37.08F;
			float y = -2.1954F;
			float z = -6F;
			iceBlock.transform.position = new Vector3 (x, y, z);
		}
	}
}
