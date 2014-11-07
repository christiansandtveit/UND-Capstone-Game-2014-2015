//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class menuMain : MonoBehaviour {

	private string[] credits = { // change over time
		"University of North Dakota\n",
		"Instructor:",
		"\tDr. Ron Marsh\n",
		"Course:",
		"\tComputer Science 448\n",
		"A Game Created By:\n",
		"Ben Carpenter:",
		"\tLevel 2 Design",
		"\tObject Art/Animation",
		"\tMusic\n",
		"Randall Howatt:",
		"\tLevel 1 Design",
		"\tInterface/Menu Design",
		"\tSound Effects\n",
		"Alex Lewis:",
		"\tEnvironment Design",
		"\tObject Art/Animation",
		"\tPuzzle Programming\n",
		"Michael Schilling:",
		"\tCharacter Controls",
		"\tObject Programming",
		"\tPuzzle Programming\n",
		"Special Thanks:\n",
		"Kasie Kinzler:",
		"\tArt Stills\n",
		"Rose Diemert:",
		"\tFirst Semester Team Member\n",
		"Mike Redlin:",
		"\tPrimary Narrator\n",
		"Ty Bommersbach:",
		"\tSecondary Narrator\n",
		"Accomodations:",
		"This game uses these art objects from OpenGameArt.org:",
		"\t\"Medieval Trestle Table\" by ulf (http://opengameart.org/users/ulf)",
		"\t\"Sickle\" by johndh (http://opengameart.org/users/johndh)",
		"\t\"Wooden Bridge 3D model\" by WeaponGuy (http://opengameart.org/users/weaponguy)\n",
		"This game uses these music files from Newgrounds.com:",
		"\t\".dystopia.\" by VegetarianMeat (http://vegetarianmeat.newgrounds.com/)",
		"\t\"Lower Dungeon\" by shesmackshard (http://shesmackshard.newgrounds.com/)\n",
		"This game uses these music files from OpenGameArt.org:",
		"\t\"Evil_bgm\" by teckpow (http://opengameart.org/users/teckpow)",
		"\t\"Shades\" by jalastram (http://opengameart.org/users/jalastram)\n",
		"This game uses these sounds from OpenGameArt.org:",
		"\t\"sell_buy_item.wav\" by Ogrebane (http://opengameart.org/users/ogrebane)",
		"\t\"sheep2.flac\" by Lamroot (http://opengameart.org/users/lamoot)",
		"\t\"waterfall1.ogg\" and \"stream1.ogg\" by kurt (http://opengameart.org/users/kurt)\n",
		"This game uses these sounds from freesound.org:",
		"\t\"bats.wav\" by soundbytez (http://www.freesound.org/people/soundbytez/)",
		"\t\"bridge.wav\" edited from Sergenious (http://www.freesound.org/people/Sergenious/)",
		"\t\"concrete blocks moving2.wav\" edited from FreqMan (http://www.freesound.org/people/FreqMan/)",
		"\t\"fire_minidisk (suonho).wav\" by suonho (http://www.freesound.org/people/suonho/)",
		"\t\"Indy Blow Darts Cue 3.wav\" edited from pscsound (http://www.freesound.org/people/pscsound/)",
		"\t\"Iron gate, street.wav\" edited from Trautwein (http://www.freesound.org/people/Trautwein/)",
		"\t\"Keys1.wav\" by EverHeat (http://www.freesound.org/people/EverHeat/)",
		"\t\"Moving a boulder.wav\" edited from BW_Clowes (http://www.freesound.org/people/BW_Clowes/)\n",
		"This game features images rendered on the CrayOwulf Cluster in the Computer Science Department using RayGL (courtesy Kris Zarns) and POVRAY (www.povray.org).\n",
		"This game is distrubted under Creative Commons 0 (https://creativecommons.org/publicdomain/zero/1.0/)"
		} ;

	private Texture mouseImage;
	private Texture wasdImage;
	private Texture eImage;
	private Texture spaceImage;
	private Texture shiftImage;

	//global variables
	public static string score;
	public static string time1;
	public static string time2;
	public static string health;

	Vector2 scrollPosition;

	public enum Page {
		Main, Levels, Credits, Controls
	}
	
	private Page currentPage;

	void Start () {
		Screen.showCursor = true;
		score = "000000";
		time1 = "00:00";
		time2 = "00:00";
		health = "5";
		Time.timeScale = 1;
		AudioListener.pause = false;
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wasdImage = Resources.Load ("WASDKey") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
	}

	void OnGUI () {
		DrawHeader (new Rect(((Screen.width - 1000) / 2), (Screen.height / 12), 1000, 400));
		switch (currentPage) {
			case Page.Main:
				MainMenu();
				break;
			case Page.Credits:
				ShowCredits();
				break;
			case Page.Controls:
				ShowControls();
				break;
			case Page.Levels:
				ShowLevels();
				break;
		}
	}

	void DrawHeader(Rect position) {
		string text = "Hunt for the Artifact";
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

	void ShowCredits() {
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 18;
		BeginPage(500, 300);
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (500), GUILayout.Height (300));
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		GUILayout.EndScrollView ();
		EndPage();
	}

	void ShowBackButton() {
		if (GUI.Button(new Rect(((Screen.width / 2) - 30), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
			currentPage = Page.Main;
		}
	}

	void ShowLevels() {
		BeginPage (200, 200);
		if (GUILayout.Button ("Level 1")) {
			Application.LoadLevel ("Introduction");
		}
		if (GUILayout.Button("Level 2")) {
			Application.LoadLevel ("Transition");
		}
		EndPage ();
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

	void ShowControls() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 30;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (400, 300);
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (400), GUILayout.Height (300));
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
		GUILayout.EndScrollView ();
		EndPage ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	}

	void MainMenu() {
		BeginPage(200,200);
		if (GUILayout.Button ("Start Game")) {
			Application.LoadLevel ("Introduction"); 
		}
		if (GUILayout.Button ("Level Select")) {
			currentPage = Page.Levels;
		}
		if (GUILayout.Button ("Controls")) {
			currentPage = Page.Controls;
		}
		if (GUILayout.Button ("Credits")) {
			currentPage = Page.Credits;
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}
		EndPage();
	}
}