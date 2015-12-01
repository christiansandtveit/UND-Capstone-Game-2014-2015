//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class ScoreBooster : Interactable {

	private guiScore scoreKeeper;
	public int value = 10000;

	void Start()
	{
		scoreKeeper = GameObject.FindObjectOfType<guiScore>();
	}

	public override void Interact (Transform interactor)
	{
		scoreKeeper.Increase(value);
		AudioSource.PlayClipAtPoint (GetComponent<AudioSource>().clip, transform.position, 0.25f);
		GameObject.Destroy(this.gameObject);
	}
}
