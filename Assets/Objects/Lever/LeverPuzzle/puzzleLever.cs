//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class puzzleLever : Interactable {

    [HideInInspector]
    public LeverPuzzle master;
    [HideInInspector]
	public int INDEX;
	private bool isOn = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
	
	public override void Interact(Transform interactor)
	{
		if(!isOn)
		{
			Activate();
			GetComponent<AudioSource>().Play();
		}
	}

	public void Activate()
	{
        isOn = true;
        animator.SetBool("IsOn", true);
		master.LeverActivated(INDEX);
	}

	public void Deactivate()
	{
		isOn = false;
        animator.SetBool("IsOn", false);
	}
}
