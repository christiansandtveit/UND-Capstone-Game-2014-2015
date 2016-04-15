//Alex Lewis
//CSci 448
using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {
	public bool hidden=false;
	// Use this for initialization
	void Start () {
		Cursor.visible = hidden;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
