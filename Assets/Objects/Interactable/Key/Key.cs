//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class Key : Interactable {

	private guiKey keyKeeper;

	void Start () {
		keyKeeper = GameObject.FindObjectOfType<guiKey>();
	}

	public override void Interact (Transform interactor)
	{
		keyKeeper.Increase();
		AudioSource.PlayClipAtPoint (audio.clip, transform.position);
		GameObject.Destroy(this.gameObject);
	}
}
