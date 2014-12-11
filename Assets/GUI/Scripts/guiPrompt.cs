//Randall Howatt
//CSci 448
//Modified by Christian Sandtveit to be able to show the crouch prompt
using UnityEngine;
using System.Collections;

public class guiPrompt : MonoBehaviour {

	private int promptSecond;
	private int numberOfKeys = 0;
	private float lastUpdate;

	private Texture eImage;
    private Texture cImage;
	private Texture spaceImage;
	private Texture shiftImage;

	public enum Page {
		None, Crouch, Interact, Jump, Sprint, Key, MoreKeys
	}
	
	private Page currentPage;

	void Start () {
		promptSecond = 0;
		lastUpdate = Time.time;
		eImage = Resources.Load ("EKey") as Texture;
        cImage = Resources.Load ("Ckey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		currentPage = Page.None;
	}

	void LateUpdate() {
		if (currentPage != Page.None) {
			if ((Time.time - lastUpdate) > 1.0f) { // update every second
				promptSecond++;
				lastUpdate = Time.time;
			}
			if (promptSecond >= 5) {
				promptSecond = 0;
				currentPage = Page.None;
			}
		}
	}

	void OnGUI() {
		switch (currentPage) {
            case Page.Crouch:
                ShowCrouch();
                break;
			case Page.Interact:
				ShowInteract();
				break;
			case Page.Jump:
				ShowJump();
				break;
			case Page.Sprint:
				ShowSprint();
				break;
			case Page.Key:
				ShowKey();
				break;
			case Page.MoreKeys:
			ShowMoreKeys (numberOfKeys);
				break;
			default:
				currentPage = Page.None;
				break;
		}
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), (3 * ((Screen.height - height) / 4)), width, height));
	}

	public void Reset() {
		currentPage = Page.None;
	}

	public void ActivateInteractPrompt() { // call to display Interact prompt
		currentPage = Page.Interact;
	}

    public void ActivateCrouchPrompt() // call to display Crouch prompt - added by Christian Sandtveit
    { 
        currentPage = Page.Crouch;
    }

	public void ActivateJumpPrompt() { // call to display Jump prompt
		currentPage = Page.Jump;
	}

	public void ActivateSprintPrompt() { // call to display Sprint prompt
		currentPage = Page.Sprint;
	}

	public void ActivateKeyPrompt() { // call to display Key prompt
		currentPage = Page.Key;
	}
	
	public void ActivateMoreKeysPrompt(int value) { // call to display More Keys prompt
		numberOfKeys = value;
		currentPage = Page.MoreKeys;
	}

	void ShowInteract() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
		GUILayout.Label (eImage, GUILayout.Width (100));
		GUILayout.Label ("to Interact with Objects", GUILayout.Width (350), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

    //ShowCrouch() added by Christian Sandtveit to be able to show crouch prompt
    void ShowCrouch()
    {
        GUI.color = Color.white;
        GUI.skin.label.fontSize = 32;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        BeginPage(1000, 100);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Press", GUILayout.Width(100), GUILayout.Height(75));
        GUILayout.Label(cImage, GUILayout.Width(100), GUILayout.Height(75));
        GUILayout.Label("to Crouch", GUILayout.Width(200), GUILayout.Height(75));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUILayout.EndArea();
    }

	void ShowJump() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
		GUILayout.Label (spaceImage);
		GUILayout.Label ("to Jump", GUILayout.Width (125), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowSprint() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Hold", GUILayout.Width (75), GUILayout.Height (75));
		GUILayout.Label (shiftImage);
		GUILayout.Label ("to Sprint", GUILayout.Width (130), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowKey() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Find Keys to Use on Locked Doors", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowMoreKeys(int value) {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		string text = "";
		if (value == 1) {
			text = ("You Need " + value + " More Key to Unlock This Door");
		}
		else {
			text = ("You Need " + value + " More Keys to Unlock This Door");
		}
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label (text, GUILayout.Width (800), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}
}