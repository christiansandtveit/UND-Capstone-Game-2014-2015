//Christian Olvier Sandtveit
//Script used to create invisible walls in the timetrial level

using UnityEngine;
using System.Collections;

public class setWallInvisible : MonoBehaviour
{

    GameObject Wall1, Wall2, Wall3, Wall4, Wall5, Wall7, Wall8, Wall9, Wall10, Wall11;

    // Use this for initialization
    void Start()
    {
        //Find the objects and sett renderer to inactive
        Wall1 = transform.Find("Wall1").gameObject;
        Wall1.GetComponent<Renderer>().enabled = false;

        Wall2 = transform.Find("Wall2").gameObject;
        Wall2.GetComponent<Renderer>().enabled = false;

        Wall3 = transform.Find("Wall3").gameObject;
        Wall3.GetComponent<Renderer>().enabled = false;

        Wall4 = transform.Find("Wall4").gameObject;
        Wall4.GetComponent<Renderer>().enabled = false;

        Wall5 = transform.Find("Wall5").gameObject;
        Wall5.GetComponent<Renderer>().enabled = false;

        Wall7 = transform.Find("Wall7").gameObject;
        Wall7.GetComponent<Renderer>().enabled = false;

        Wall8 = transform.Find("Wall8").gameObject;
        Wall8.GetComponent<Renderer>().enabled = false;

        Wall9 = transform.Find("Wall9").gameObject;
        Wall9.GetComponent<Renderer>().enabled = false;

        Wall10 = transform.Find("Wall10").gameObject;
        Wall10.GetComponent<Renderer>().enabled = false;

        Wall11 = transform.Find("Wall11").gameObject;
        Wall11.GetComponent<Renderer>().enabled = false;
    }
}