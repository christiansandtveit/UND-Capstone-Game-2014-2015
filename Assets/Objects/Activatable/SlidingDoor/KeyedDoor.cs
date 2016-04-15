//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class KeyedDoor : Interactable {

	public int requiredKeys = 3;
	private int keysLeft;

	void Start()
	{
		keysLeft = requiredKeys;
	}

	public override void Interact (Transform interactor)
	{
		print ("slidingDoor interact");
		guiKey keyGod = Camera.main.GetComponent<guiKey>();
		int keyCount = keyGod.currentKeys;
		if (keyCount < requiredKeys)
		{
			keyGod.Decrease(keyCount);
			keysLeft -= keyCount;
			if (keysLeft != 0 ) {
				FindObjectOfType<guiPrompt>().ActivateMoreKeysPrompt (keysLeft);
			}
		}
		else
		{
			keyGod.Decrease(requiredKeys);
			keysLeft = 0;

		}
		if (keysLeft <= 0)
		{
			GetComponent<SlidingDoor>().Activate();
			if (GetComponent<AudioSource>().isPlaying == false)
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
