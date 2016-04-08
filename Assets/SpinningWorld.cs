using UnityEngine;
using System.Collections;

public class SpinningWorld : MonoBehaviour {

    public int randomLowObject = 0;
    public int randomHighObject = 5;
    public int randomLowWorld = 0;
    public int randomhighWorld = 3;
    private int turnSpeedObject = 0;
    private int turnSpeedWorld = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        turnSpeedObject = Random.Range(randomLowObject, randomHighObject);
        turnSpeedWorld = Random.Range(randomLowWorld, randomLowWorld);
        transform.Rotate(Vector3.right, turnSpeedObject * Time.deltaTime);
        transform.Rotate(Vector3.up, turnSpeedObject * Time.deltaTime);
    }
}
