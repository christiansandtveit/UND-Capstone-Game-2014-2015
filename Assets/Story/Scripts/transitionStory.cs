//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class transitionStory : MonoBehaviour {

	private float beginTime;
	private Texture transitionStill;
	
	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		transitionStill = Resources.Load ("TransitionStill") as Texture;
		beginTime = Time.time;
		GetComponent<AudioSource>().Play ();
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 12.0f) {
			Application.LoadLevel("Level2");
		}
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel ("Level2");
		}
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), transitionStill);
	}
}