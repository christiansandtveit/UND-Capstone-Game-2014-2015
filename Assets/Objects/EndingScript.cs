using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {

    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    bool showTextKey;
    //public static bool timeKeyCollected, teleKeyCollected, iceKeyCollected;
    

	// Use this for initialization
	void Start () {
        rayLength = 1.5f;
        showTextKey = false;
        //timeKeyCollected = false;
        //teleKeyCollected = false;
        //iceKeyCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = camera.ScreenPointToRay(new Vector3(x, y)); //Ray goes towards middle of screen

        if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
        {
            if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
            {
                if (hit.collider.tag == "Key1") //If the ray hit the object with label Lever1
                {
                    GameObject k1 = GameObject.FindWithTag("Key1");
                    k1.renderer.enabled = false;
                    KeyManager.timeKeyCollected = true;
                    showTextKey = true;
                    print("interactWithKey");
                    Invoke("TeleportHub", 5.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
                if (hit.collider.tag == "Key2") //If the ray hit the object with label Lever1
                {
                    GameObject k2 = GameObject.FindWithTag("Key2");
                    k2.renderer.enabled = false;
                    KeyManager.teleKeyCollected = true;
                    showTextKey = true;
                    print("interactWithKey");
                    Invoke("TeleportHub", 5.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
                if (hit.collider.tag == "Key3") //If the ray hit the object with label Lever1
                {
                    GameObject k3 = GameObject.FindWithTag("Key3");
                    k3.renderer.enabled = false;
                    KeyManager.iceKeyCollected = true;
                    showTextKey = true;
                    print("interactWithKey");
                    Invoke("TeleportHub", 5.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
                if (hit.collider.tag == "TeleportTime") //If the ray hit the object with label Lever1
                {
                    TeleportTime();
                }
                if (hit.collider.tag == "TeleportTele") //If the ray hit the object with label Lever1
                {
                    TeleportTele();
                }
                if (hit.collider.tag == "TeleportIce") //If the ray hit the object with label Lever1
                {
                    TeleportIce();
                }
            }
        }
	}

    //Display text to screen
    void OnGUI()
    {
        if (showTextKey == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 600), "You have successfully collected the key in this level! Good job! You will now be teleported outside this level.");
        }
    }

    void TeleportHub()
    {
        Application.LoadLevel("level3Hub");
    }

    void TeleportTime()
    {
        Application.LoadLevel("TimeTrialLevel");
    }

    void TeleportTele()
    {
        Application.LoadLevel("TeleportPuzzle");
    }

    void TeleportIce()
    {
        Application.LoadLevel("iceCave");
    }
}
