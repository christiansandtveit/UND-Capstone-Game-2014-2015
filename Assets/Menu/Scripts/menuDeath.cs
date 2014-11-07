//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class menuDeath : MonoBehaviour {
	
	private bool isDead=false;

	private Texture blackScreen;

	public enum Page {
		None, Main
	}
	
	private Page currentPage=Page.None;
	
	void Start () {
		blackScreen = Resources.Load ("BlackScreen") as Texture;
	}
	
	void LateUpdate () {
		if (isDead) { 
			switch(currentPage) {
				case Page.None:
					StartDeath();
					break;
				default:
					currentPage = Page.Main;
					break;
			}
		}
	}
	
	void OnGUI () {
		if (isDead) {
			switch (currentPage) {
			case Page.Main:
				GUI.color = new Color32(255, 255, 255, 175);
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen, ScaleMode.StretchToFill, true);
				DeathMenu();
				break;
			}
			DrawHeader (new Rect(((Screen.width - 1000) / 2), (Screen.height / 8), 1000, 400));
		}
	}
	
	public void killPlayer() { // call to display Death Menu
		isDead = true;
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}
	
	private void DeathMenu() {
		BeginPage(200,200);
		GUI.skin.label.fontSize = 32;
		GUI.color = Color.white;
		string trysRemaining = GetComponent<guiHealth> ().Get ();
		string restartText;
		if (!trysRemaining.Equals ("1")) {
			restartText = ("Restart (" + trysRemaining + " lives remaining)");
		}
		else {
			restartText = ("Restart (" + trysRemaining + " life remaining)");
		}
		if (!trysRemaining.Equals ("0")) { // only display if current lives are greater than zero
			if (GUILayout.Button (restartText)) {
				EndDeath ();
			}
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("MainMenu");
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}
		GUILayout.EndArea();
	}

	private void DrawHeader(Rect position) {
		string text = "You Are Dead";
		GUI.skin.label.fontSize = 64;
		GUIStyle centeredText = new GUIStyle ("label");
		centeredText.alignment = TextAnchor.UpperCenter;
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text, centeredText);
		position.x += 2;
		GUI.Label(position, text, centeredText);
		position.x--;
		position.y--;
		GUI.Label(position, text, centeredText);
		position.y += 2;
		GUI.Label(position, text, centeredText);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text, centeredText); // regular text
	}
	
	void StartDeath() {
		isDead = true;
		AudioListener.pause = true;
		GetComponent<guiHealth> ().Decrease ();
		GetComponent<menuPause> ().PauseGame (false);
        GetComponent<menuPause>().enabled = false;
		currentPage = Page.Main;
	}
	
	void EndDeath() {
		FindObjectOfType<Manager>().Reset();
		FindObjectOfType<LevelManager>().Reset ();
		isDead = false;
		AudioListener.pause = false;
		GetComponent<guiPrompt> ().Reset ();
		GetComponent<menuPause> ().enabled = true;
		GetComponent<menuPause> ().UnPauseGame (false);
		currentPage = Page.None;
	}
}