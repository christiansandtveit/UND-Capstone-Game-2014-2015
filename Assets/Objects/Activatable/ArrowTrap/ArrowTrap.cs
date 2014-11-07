//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class ArrowTrap : Activatable {

	private ParticleSystem arrowParticles;

	void Start()
	{
		arrowParticles = this.GetComponentInChildren<ParticleSystem>();
	}

	public override void Activate ()
	{
		if (arrowParticles != null && !arrowParticles.isPlaying)
		{
			audio.Play ();
			arrowParticles.Play();
			Destroy(arrowParticles, arrowParticles.duration);
		}
	}

	public override void Deactivate()
	{
		// Nothing (arrow trap can't be deactivated as its a one shot device)
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && arrowParticles != null && arrowParticles.isPlaying)
		{
			other.gameObject.GetComponent<Manager>().Kill();
		}
	}

    public override void Reset() { }
}
