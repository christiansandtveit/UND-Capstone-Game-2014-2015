//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class FOVChanger : MonoBehaviour {

    private CharacterMotor characterMotor;
    public float changeSpeed = 30.0f;

    public float normalFOV = 60.0f;
    public float sprintingFOV = 65.0f;
    void Start ()
    {
        characterMotor = transform.parent.GetComponent<CharacterMotor> ();
    }

    void Update ()
    {
        if (characterMotor.IsSprinting())
        {
            GetComponent<Camera>().fieldOfView = Mathf.Min (GetComponent<Camera>().fieldOfView + changeSpeed * Time.deltaTime, sprintingFOV);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Max (GetComponent<Camera>().fieldOfView - changeSpeed * Time.deltaTime, normalFOV);
        }
    }

}
