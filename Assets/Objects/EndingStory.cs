
using UnityEngine;
using System.Collections;

public class EndingStory : MonoBehaviour
{

    private float beginTime;
    private Texture endStill;

    void Start()
    {
        Time.timeScale = 1;
        endStill = Resources.Load("end") as Texture;
        beginTime = Time.time;
    }

    void LateUpdate()
    {
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
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), endStill);
    }
}