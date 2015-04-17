//Christian Oliver Sandtveit
//Script which will create a trigger which will show a hint to the player when entered

using UnityEngine;
using System.Collections;

public class TeleportTimeTrigger : MonoBehaviour
{
    //Variables
    bool showHint;

    // Use this for initialization
    void Start()
    {
        showHint = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            showHint = true;
            Invoke("HideHint", 5.0F);
        }
    }

    void OnGUI()
    {
        if (showHint == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Press E to enter!");
        }
    }

    void HideHint()
    {
        showHint = false;
    }
}
