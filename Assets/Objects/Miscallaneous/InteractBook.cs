//Written by Christian Sandtveit
//Script which is used so that player can interact with books pressing the interact button (e)

using UnityEngine;
using System.Collections;

public class InteractBook : MonoBehaviour
{
    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    bool showBook1;

    // Use this for initialization
    void Start()
    {
        rayLength = 1.5f;
        showBook1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit; //Used to query what the ray hit
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Ray goes towards the mouse cursor

        if (Input.GetButton("Interact")) //If interact button is pressed, a ray will be sent out
        {
            if (Physics.Raycast(ray, out hit, rayLength)) //If the ray hit something
            {
                if (hit.collider.tag == "Book1") //If the ray hit the object with label Book1
                {
                    showBook1 = true; //Allow OnGUI function to display on screen
                    Invoke("Hide", 3.0F); //Invoke the Hide function after 3seconds, makes the text dissapear
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
    }

    //Set bool variable to false, so that text dissapears
    void Hide()
    {
        showBook1 = false;
    }
}
