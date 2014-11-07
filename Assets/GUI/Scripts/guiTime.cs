//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class guiTime : MonoBehaviour {

	private int currentSecond;
	private int currentMinute;
	private float lastUpdate;
	private string displayTime;

	void Start() {
		currentSecond = 0;
		currentMinute = 0;
		lastUpdate = 0;
		displayTime = "";
	}
	
	void Update() {
		if ((Time.time - lastUpdate) > 1.0f) { // update every second
			currentSecond++;
			lastUpdate = Time.time;
		}
		if (currentSecond == 60) {
			currentSecond = 0;
			currentMinute++;
		}
		if (currentMinute < 10 && currentSecond < 10) { // case 1: 0m:0s
			displayTime = "0" + currentMinute.ToString () + ":0" + currentSecond.ToString ();
		}
		else if (currentMinute < 10) { // case 2: 0m:ss
			displayTime = "0" + currentMinute.ToString () + ":" + currentSecond.ToString ();
		}
		else if (currentSecond < 10) { // case 3: mm:0s
			displayTime = "" + currentMinute.ToString () + ":0" + currentSecond.ToString ();
		}
		else { // case 4: mm:ss
			displayTime = "" + currentMinute.ToString () + ":" + currentSecond.ToString ();
		}
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 20;
		GUI.color = Color.white;
		DrawOutline (new Rect ((Screen.width - (Screen.width / 6)), (Screen.height / 8), 200, 64), ("Time:\t\t" + displayTime));
	}

	void DrawOutline(Rect position, string text) {
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text);
		position.x += 2;
		GUI.Label(position, text);
		position.x--;
		position.y--;
		GUI.Label(position, text);
		position.y += 2;
		GUI.Label(position, text);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text); // regular text
	}

	public void Set(int minute, int second) {
		currentMinute = minute;
		currentSecond = second;
	}

	public string Get() {
		return displayTime;
	}
}