//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class menuPause : MonoBehaviour
{
	private float savedTimeScale;

	private MouseLook playerCamera;
	private	MouseLook mainCamera;
	
	private Texture mouseImage;
	private Texture wasdImage;
	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;
	private Texture blackScreen;
	
	public enum Page {
		None, Main, Controls
	}
	
	private Page currentPage;
	
	void Start() {
		Time.timeScale = 1;
		playerCamera = GameObject.Find ("Player").GetComponent<MouseLook>();
		mainCamera = Camera.main.GetComponent<MouseLook>();
		GetComponent<HeadBob> ().enabled = true;
		GetComponent<guiCrosshair> ().enabled = true;
		AudioListener.pause = false;
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wasdImage = Resources.Load ("WASDKey") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
	}
	
	void LateUpdate () {
		if (Input.GetKeyDown("escape") || Input.GetKeyDown ("return")) {
			switch (currentPage) {
			case Page.None: 
				PauseGame(true); 
				break;
			default: 
				currentPage = Page.Main;
				break;
			}
		}
	}
	
	void OnGUI () {
		if (IsGamePaused()) {
			GUI.color = new Color32(255, 255, 255, 175);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen);
			switch (currentPage) {
				case Page.Main:
					MainPauseMenu();
					break;
				case Page.Controls:
					ShowControls ();
					break;
			}
		}   
	}
	
	void ShowBackButton() {
		if (GUI.Button(new Rect(((Screen.width / 2) - 30), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
			currentPage = Page.Main;
		}
	}
	
	void ShowControls() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 30;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (400, 400);
		GUILayout.BeginHorizontal ();
		GUILayout.BeginVertical ();
		GUILayout.Label (mouseImage);
		GUILayout.Label (wasdImage);
		GUILayout.Label (eImage);
		GUILayout.Label (spaceImage);
		GUILayout.Label (shiftImage);
		GUILayout.EndVertical ();
		GUILayout.BeginVertical ();
		GUILayout.Label ("Camera", GUILayout.Height (75));
		GUILayout.Label ("Movement", GUILayout.Height (75));
		GUILayout.Label ("Interact", GUILayout.Height (55));
		GUILayout.Label ("Jump", GUILayout.Height (75));
		GUILayout.Label ("Sprint", GUILayout.Height (75));
		GUILayout.EndVertical ();
		GUILayout.EndHorizontal ();
		EndPage ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	void MainPauseMenu() {
		GUI.color = Color.white;
		BeginPage(200,200);
		if (GUILayout.Button ("Resume")) {
			UnPauseGame(true);
		}
		if (GUILayout.Button ("Controls")) {
			currentPage = Page.Controls;
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("MainMenu");
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}
		EndPage();
	}
	
	public void PauseGame(bool check) {
		Screen.showCursor = true;
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		playerCamera.enabled = false;
		mainCamera.enabled = false;
		GetComponent<HeadBob> ().enabled = false;
		GetComponent<guiCrosshair> ().enabled = false;
		GetComponent<guiPrompt> ().enabled = false;
		if (check) { // Death flag check. If false it does not display the Pause Menu and only pauses the game.
			currentPage = Page.Main;
		}
	}
	
	public void UnPauseGame(bool check) {
		Time.timeScale = savedTimeScale;
		GetComponent<MouseLook>().enabled = true;
		AudioListener.pause = false;
		playerCamera.enabled = true;
		mainCamera.enabled = true;
		GetComponent<HeadBob> ().enabled = true;
		GetComponent<guiCrosshair> ().enabled = true;
		GetComponent<guiPrompt> ().enabled = true;
		if (check) {
			currentPage = Page.None;
		}
		Screen.showCursor = false;
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
}