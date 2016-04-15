//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class Drawbridge : Activatable {

    public override void Activate()
    {
        GetComponent<Animator>().SetBool("Lower Bridge", true);
		GetComponent<AudioSource>().Play ();
    }

    public override void Deactivate() { }
    public override void Reset() { }
}
