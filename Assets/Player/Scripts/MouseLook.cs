//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 10.0f;
	public float sensitivityY = 10.0f;

    // How much of the original sensitivity will be used while sprinting?
    // For example, if sensitivity is 15 and sprintSensitivityModifier is 0.1f,
    // then sprinting sensitivity will be 1.5f

    private float currentSensitivityX;
    private float currentSensitivityY;

	public float minimumX = -360.0f;
	public float maximumX = 360.0f;

	public float minimumY = -60.0f;
	public float maximumY = 60.0f;

	float rotationY = 0.0f;

    public CharacterMotor characterMotor;

	void Update ()
	{
        UpdateCurrentSensitivity ();
		if (axes == RotationAxes.MouseXAndY)
		{
            float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * currentSensitivityX;

            rotationY += Input.GetAxis ("Mouse Y") * currentSensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * currentSensitivityX, 0);
		}
		else
		{
            rotationY += Input.GetAxis ("Mouse Y") * currentSensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start ()
	{
        //characterMotor = transform.parent.GetComponent<CharacterMotor> ();
	}

    void UpdateCurrentSensitivity ()
    {
        if (Input.GetButton("Sprint") && characterMotor.LocalizedInput.z > 0.0f)
        {
            currentSensitivityX = sensitivityX * 0.6f;
            currentSensitivityY = sensitivityY * 0.6f;
        }
        else
        {
            currentSensitivityX = sensitivityX;
            currentSensitivityY = sensitivityY;
        }
    }
}