//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class guiScore : MonoBehaviour {

	public int totalScore = 0;
	private string displayScore = "";

	void Start() {
		totalScore = 0;
		displayScore = "";
		Set (System.Convert.ToInt32 (menuMain.score));
	}

	void Update() {
		displayScore = ScoreFormat (totalScore);
	}

	string ScoreFormat(int s) {
		if (s == 0) {
			return ("000000");
		}
		else if (s < 10) {
			return ("00000" + s);
		}
		else if (s < 100) {
			return ("0000" + s);
		}
		else if (s < 1000) {
			return ("000" + s);
		}
		else if (s < 10000) {
			return ("00" + s);
		}
		else if (s < 100000) {
			return ("0" + s);
		}
		else {
			return ("" + s);
		}
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 20;
		GUI.color = Color.white;
		DrawOutline (new Rect ((Screen.width - (Screen.width / 6)), (Screen.height / 20), 200, 64), ("Score:\t\t" + displayScore));
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

	public void Increase(int value) {
		totalScore += value;
		menuMain.score = ScoreFormat (totalScore);
	}

	public void Set(int value) {
		totalScore = value;
	}

	public string Get() {
		return displayScore;
	}
}