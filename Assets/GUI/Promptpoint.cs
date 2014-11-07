//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class Promptpoint : MonoBehaviour {

	public string promptType = "";
	private bool shownInteract = false;
	private bool shownSprint = false;
	private bool shownJump = false;
	private bool shownKey = false;
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			if (promptType.Equals ("Interact") && shownInteract == false) {
				shownInteract = true;
				FindObjectOfType<guiPrompt>().ActivateInteractPrompt ();
			}
			else if (promptType.Equals ("Sprint") && shownSprint == false) {
				shownSprint = true;
				FindObjectOfType<guiPrompt>().ActivateSprintPrompt();
			}
			else if (promptType.Equals ("Jump") && shownJump == false) {
				shownJump = true;
				FindObjectOfType<guiPrompt>().ActivateJumpPrompt();
			}
			else if (promptType.Equals ("Key") && shownKey == false) {
				shownKey = true;
				FindObjectOfType<guiPrompt>().ActivateKeyPrompt();
			}
		}
	}
}