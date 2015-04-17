using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour {

    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    bool showText;

	// Use this for initialization
	void Start () {
        rayLength = 1.5f;
        showText = false;
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
                    showText = true;
                    print("interactWithKey");
                    Invoke("Teleport", 10.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
            }
        }
	}

    //Display text to screen
    void OnGUI()
    {
        if (showText == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 600), "You have successfully collected the key in this level! Good job! You will now be teleported outside this level.");
        }
    }

    void Teleport()
    {
        Application.LoadLevel("Hub");
    }
}
