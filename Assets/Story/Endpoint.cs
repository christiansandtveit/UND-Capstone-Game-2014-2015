//Randall Howatt
//CSci 448
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Endpoint : MonoBehaviour {

	public int currentLevel = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (currentLevel == 1) {
				menuMain.time1 = FindObjectOfType<guiTime> ().Get ();
                SceneManager.LoadScene("ScoreBoard1");
			}
			else if (currentLevel == 2) {
				menuMain.time2 = FindObjectOfType<guiTime> ().Get ();
                SceneManager.LoadScene("level3Hub");
			}
            else if (currentLevel == 13)
            {
                KeyManager.timeKeyCollected = false;
                KeyManager.teleKeyCollected = false;
                KeyManager.iceKeyCollected = false;
                menuMain.time2 = FindObjectOfType<guiTime>().Get();
                SceneManager.LoadScene("FallingLevel");
            }
            else if(currentLevel == 14)
            {
                menuMain.time2 = FindObjectOfType<guiTime>().Get();
                SceneManager.LoadScene("Ending");
            }
		}
	}
}