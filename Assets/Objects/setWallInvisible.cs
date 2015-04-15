//Christian Olvier Sandtveit
//Script used to create invisible walls in the timetrial level

using UnityEngine;
using System.Collections;

public class setWallInvisible : MonoBehaviour
{

    GameObject Wall1, Wall2, Wall3, Wall4, Wall5, Wall6, Wall7, Wall8, Wall9, Wall10, Wall11;

    // Use this for initialization
    void Start()
    {
        //Find the objects and sett renderer to inactive
        Wall1 = transform.Find("Wall1").gameObject;
        Wall1.renderer.enabled = false;

        Wall2 = transform.Find("Wall2").gameObject;
        Wall2.renderer.enabled = false;

        Wall3 = transform.Find("Wall3").gameObject;
        Wall3.renderer.enabled = false;

        Wall4 = transform.Find("Wall4").gameObject;
        Wall4.renderer.enabled = false;

        Wall5 = transform.Find("Wall5").gameObject;
        Wall5.renderer.enabled = false;

        Wall6 = transform.Find("Wall6").gameObject;
        Wall6.renderer.enabled = false;

        Wall7 = transform.Find("Wall7").gameObject;
        Wall7.renderer.enabled = false;

        Wall8 = transform.Find("Wall8").gameObject;
        Wall8.renderer.enabled = false;

        Wall9 = transform.Find("Wall9").gameObject;
        Wall9.renderer.enabled = false;

        Wall10 = transform.Find("Wall10").gameObject;
        Wall10.renderer.enabled = false;

        Wall11 = transform.Find("Wall11").gameObject;
        Wall11.renderer.enabled = false;
    }
}