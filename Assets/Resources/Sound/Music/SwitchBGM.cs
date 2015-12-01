//Ben Carpenter
//CSci 448
using UnityEngine;
using System.Collections;

public class SwitchBGM : MonoBehaviour {
	
	public AudioClip outsideClip;
	public AudioClip insideClip;
	private bool isColliding;
	private bool inside;
	public float fadeSpeed;
	private bool done;
	public float inVol;
	public float outVol;
	private float vol;

	// Use this for initialization
	void Start () {
		isColliding = false;
	}

	void OnTriggerEnter(Collider c) {

		if (c.tag == "Player") {
			isColliding = true;
			inside = true;
			vol = inVol;
			done = false;
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.tag == "Player") {
			isColliding = true;
			inside = false;
			vol = outVol;
			done = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (isColliding && GetComponent<AudioSource>().volume > .01) {
			GetComponent<AudioSource>().volume -= fadeSpeed * Time.deltaTime;
		}
		if (GetComponent<AudioSource>().volume <= .01 && !done) {
			done = true;
			isColliding = false;
			GetComponent<AudioSource>().clip = inside ? insideClip : outsideClip;
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop  = true;
		}

		if (GetComponent<AudioSource>().volume <= vol && !isColliding) {
			GetComponent<AudioSource>().volume += fadeSpeed * Time.deltaTime;
		}
	}
}
