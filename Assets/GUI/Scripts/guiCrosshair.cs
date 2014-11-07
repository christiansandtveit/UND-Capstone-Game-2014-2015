//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class guiCrosshair : MonoBehaviour {

	private Texture crosshairImage;

	void Start () {
		crosshairImage = Resources.Load ("Crosshair") as Texture;
	}

	void OnGUI () {
		GUI.Label (new Rect ((Screen.width / 2) - 20, (Screen.height / 2) - 20, 40, 40), crosshairImage);
	}

}
