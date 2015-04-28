//Christian Oliver Sandtveit
//Script which creates the final scene of the game


using UnityEngine;
using System.Collections;

public class EndingStory : MonoBehaviour
{

    private float beginTime;
    private Texture endStill;

    void Start()
    {
        Time.timeScale = 1;
        //Load the resource end as a texture. end is a png file
        endStill = Resources.Load("end") as Texture;
        beginTime = Time.time;
    }

    void LateUpdate()
    {
        /*Show for max 5 seconds before loading main menu */
        if ((Time.time - beginTime) >= 5.0f)
        {
            Application.LoadLevel("MainMenu");
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.LoadLevel("MainMenu");
        }
    }

    void OnGUI()
    {
        /*Draw out the final scene (end.png) */
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), endStill);
    }
}