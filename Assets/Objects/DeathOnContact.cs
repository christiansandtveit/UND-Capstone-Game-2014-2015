//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DeathOnContact : MonoBehaviour {

    public static bool playerDead; //Static variable, will be accessed in other scripts

    // Use this for initialization
    void Start()
    {
        playerDead = false;
    }



	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.root.GetComponent<Manager>().Kill ();
            playerDead = true;
            Invoke("DeactivatePlayerDead", 2.0F);

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.transform.root.GetComponent<Manager>().Kill ();
            playerDead = true;
            Invoke("DeactivatePlayerDead", 2.0F);
		}
	}

    //Functiont to deactivate playerDead
    void DeactivatePlayerDead()
    {
        playerDead = false;
    }
}
