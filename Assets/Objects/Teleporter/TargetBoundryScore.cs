using UnityEngine;
using System.Collections;

public class TargetBoundryScore : MonoBehaviour {
    private guiScore scoreKeeper;
    public int value = 10000;
	// Use this for initialization
	void Start () {
        scoreKeeper = GameObject.FindObjectOfType<guiScore>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        scoreKeeper.Increase(value);
    }
}
