using UnityEngine;
using System.Collections;

public class Target : Interactable
{

    public Activatable[] thingsToActivate;
    public bool isOneTimeTrigger = false;
    private bool isOn = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact(Transform interactor)
    {
        Toggle();
    }

    public virtual void Toggle()
    {
        print(animator.GetBool("IsOn"));
        if (!isOn)
        {
            for (int i = 0; i < thingsToActivate.Length; i++)
            {
                thingsToActivate[i].Activate();
            }
            isOn = true;
            print("lever on");
            audio.Play();
            animator.SetBool("IsOn", true);

        }
        // only allow deactivation if the lever allows itself to be toggled indefinitely
        else if (!isOneTimeTrigger)
        {
            for (int i = 0; i < thingsToActivate.Length; i++)
            {
                thingsToActivate[i].Deactivate();
            }
            isOn = false;
            print("lever off");
            audio.Play();
            animator.SetBool("IsOn", false);
        }
    }
}
