//Written by Christian Sandtveit
//Script which is used so that player can interact with books pressing the interact button (e)

using UnityEngine;
using System.Collections;

public class InteractBook : MonoBehaviour
{
    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    bool showBook1, showBook2, showBook3, showBook4, showBook5,showBook6;

    // Use this for initialization
    void Start()
    {
        rayLength = 1.5f;
        showBook1 = false;
        showBook2 = false;
		showBook3 = false;
        showBook4 = false;
        showBook5 = false;
		showBook6 = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit; //Used to query what the ray hit
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = camera.ScreenPointToRay(new Vector3(x, y)); //Ray goes towards middle of screen

        if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
        {
            if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
            {
                if (hit.collider.tag == "Book1") //If the ray hit the object with label Book1
                {
                    showBook1 = true; //Allow OnGUI function to display on screen
                    Invoke("HideBook1", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
                if (hit.collider.tag == "Book2") //If the ray hit the object with label Book2
                {
                    showBook2 = true; //Allow OnGUI function to display on screen
                    Invoke("HideBook2", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
				if (hit.collider.tag == "Book3") //If the ray hit the object with label Book2
				{
					showBook3 = true; //Allow OnGUI function to display on screen
					Invoke("HideBook3", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
				}
                if (hit.collider.tag == "Book4") //If the ray hit the object with label Book2
                {
                    showBook4 = true; //Allow OnGUI function to display on screen
                    Invoke("HideBook4", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
                if (hit.collider.tag == "Book5") //If the ray hit the object with label Book2
                {
                    print("B5");
                    showBook5 = true; //Allow OnGUI function to display on screen
                    Invoke("HideBook5", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
                }
				if (hit.collider.tag == "Book6") //If the ray hit the object with label Book2
				{
					print("B6");
					showBook6 = true; //Allow OnGUI function to display on screen
					Invoke("HideBook6", 5.0F); //Invoke the Hide function after 5seconds, makes the text dissapear
				}
            }
        }
    }

    //Display text to screen
    void OnGUI()
    {
        if (showBook1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Search the caves for keys and treasures!");
        }
        if (showBook2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Pull the lever and see what happens!");
        }
		if (showBook3)
		{
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Find the keys to unlock the gate.");
		}
        if (showBook4)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "All you need is belief! Try walking to the door.");
        }
        if (showBook5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "Pick up a dart with E. Throw with left mouse");
        }
		if (showBook6)
		{
			GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "Push the ice block by clicking E. Reset the ice block by clicking R.");
		}
    }

    //Set bool variable to false, so that text dissapears
    void HideBook1()
    {
        showBook1 = false;
    }

    //Set bool variable to false, so that text dissapears
    void HideBook2()
    {
        showBook2 = false;
    }

	//Set bool variable to false, so that text dissapears
	void HideBook3()
	{
		showBook3 = false;
	}

    //Set bool variable to false, so that text dissapears
    void HideBook4()
    {
        showBook4 = false;
    }

    //Set bool variable to false, so that text dissapears
    void HideBook5()
    {
        showBook5 = false;
    }
	//Set bool variable to false, so that text dissapears
	void HideBook6()
	{
		showBook6 = false;
	}
}
