//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class HeadBob : MonoBehaviour
{
	private float timer = 0.0f;
	private float midpoint;
	public float normalBobSpeed = 0.15f;
	public float normalBobAmount = 0.03f;
    public float sprintingBobSpeed = 0.18f;
    public float sprintingBobAmount = 0.04f;
    public float minimumSpeedForBob = 0.5f;
    private CharacterMotor characterMotor;
	private AudioClip footSteps;

	void Start()
	{
		midpoint = this.transform.localPosition.y;
        characterMotor = this.transform.parent.GetComponent<CharacterMotor> ();
		footSteps = Resources.Load ("Sound/footSteps") as AudioClip;
	}

	void Update ()
	{
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
        float bobSpeed, bobAmount;

        if (characterMotor.IsSprinting ())
        {
            bobSpeed = sprintingBobSpeed;
            bobAmount = sprintingBobAmount;
        }
        else
        {
            bobSpeed = normalBobSpeed;
            bobAmount = normalBobAmount;
        }

		if (!characterMotor.grounded || characterMotor.movement.velocity.magnitude < minimumSpeedForBob)
		{
			timer = 0.0f;
            waveslice = 0.0f;
		}
		else
		{
			waveslice = Mathf.Sin(timer);
			timer += bobSpeed;
			if (timer > Mathf.PI * 2) 
			{
				if(characterMotor.movement.velocity.magnitude != 0.0f)
				{
					audio.PlayOneShot (footSteps, 0.025f);
				}
				timer -= Mathf.PI * 2;
			}
		}

		if (waveslice != 0.0f)
		{
			float amountToMove = waveslice * bobAmount;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
			totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
			amountToMove *= totalAxes;
			transform.localPosition = new Vector3(transform.localPosition.x, midpoint + amountToMove, transform.localPosition.z);
		}
		else
		{
			transform.localPosition = new Vector3(transform.localPosition.x, midpoint, transform.localPosition.z);
		}
	}
}
