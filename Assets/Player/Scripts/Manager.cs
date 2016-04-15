//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
	private Camera playerCamera;
	public float interactDistance = 1.25f;
	public LayerMask layerMask;
    public Checkpoint lastCheckpoint;
	private AudioClip TyJump;
	private AudioClip TyBreathe;
	private CharacterMotor motor;

	void Start()
	{
		playerCamera = GetComponentInChildren<Camera>();
		TyJump = Resources.Load ("Sound/TyJump") as AudioClip;
		motor = GetComponent<CharacterMotor> ();
	}

	void Update()
	{
        RaycastHit hitInfo;
        if (Input.GetButtonDown("Interact"))
        {
		    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactDistance, layerMask))
		    {
				hitInfo.transform.gameObject.GetComponent<Interactable>().Interact(this.playerCamera.GetComponentInChildren<Rigidbody>().transform);
			}
		}
		if (motor.IsSprinting () && motor.movement.velocity.magnitude >= 0.5) {
			if (!GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().Play ();
			}
		}
		else
		{
			GetComponent<AudioSource>().Stop ();
		}
		if (Input.GetButtonDown ("Jump") && motor.grounded)
		{
			AudioSource.PlayClipAtPoint (TyJump, transform.position, 0.15f);
		}
	}
    
    public void Reset()
    {
        transform.position = lastCheckpoint.transform.position;
    }

    public void Kill()
    {
        GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
        FindObjectOfType<menuDeath>().killPlayer();
    }

    void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.GetComponent<DeathOnContact>() != null)
        {
            Kill();
        }
    }
}
