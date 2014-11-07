//Alex Lewis
//CSci 448
using UnityEngine;
using System.Collections;

public class SplashPage : MonoBehaviour {

	private float beginTime;
	private Texture Splash;
	
	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		Splash = Resources.Load ("mrbacolored") as Texture;
		beginTime = Time.time;
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 4.0f) {
			Application.LoadLevel("MainMenu");
		}
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel ("MainMenu");
		}
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Splash);
	}
}