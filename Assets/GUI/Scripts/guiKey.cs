//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class guiKey : MonoBehaviour {

	public int currentKeys;
	public string displayKeys;

	private Texture keyImage;

	void Start() {
		currentKeys = 0;
		displayKeys = "";
		keyImage = Resources.Load ("Key") as Texture;
	}

	void Update() {
		displayKeys = "x " + currentKeys;
	}

	void OnGUI () {
		GUI.skin.label.fontSize = 16;
		GUI.color = Color.white;
		DrawOutline (new Rect((Screen.width / 12), (Screen.height / 8), 64, 64), displayKeys);
		GUI.Label (new Rect ((Screen.width / 50), (Screen.height / 10), 64, 64), keyImage);
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

	public void Increase() {
		currentKeys++;
	}

	public void Decrease(int value) {
		currentKeys -= value;
	}

	public void Set(int value) {
		currentKeys = value;
	}

	public void Reset() {
		currentKeys = 0;
	}	
}
