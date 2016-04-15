//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class LightsOnLever : Interactable {

	public Torch myTorch;
    private bool isOn = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

	public override void Interact(Transform interactor)
	{
		Toggle();
	}

	public void Toggle()
	{
        isOn = !isOn;
        animator.SetBool("IsOn", isOn);
		if(myTorch.Active)
		{
			myTorch.Deactivate();
		}
		else
		{
			myTorch.Activate();
		}
		GetComponent<AudioSource>().Play ();
	}
}
