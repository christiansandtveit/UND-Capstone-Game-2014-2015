//Randall Howatt
//CSci 448
using UnityEngine;
using System.Collections;

public class Endpoint : MonoBehaviour {

	public int currentLevel = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (currentLevel == 1) {
				menuMain.time1 = FindObjectOfType<guiTime> ().Get ();
				Application.LoadLevel ("ScoreBoard1");
			}
			else if (currentLevel == 2) {
				menuMain.time2 = FindObjectOfType<guiTime> ().Get ();
				Application.LoadLevel ("level3Hub");
			}
		}
	}
}