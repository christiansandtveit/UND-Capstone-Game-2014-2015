//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DeathOnContact : MonoBehaviour {

    public static bool playerDeadL; //Static variable, will be accessed in other scripts
    public static bool playerDead; //Static variable, will be accessed in other scripts
    public static bool playerDeadR; //Static variable, will be accessed in other scripts

    // Use this for initialization
    void Start()
    {
        playerDeadL = false;
        playerDead = false;
        playerDeadR = false;
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
            if (gameObject.name == "Left")
            {
                print("left death");
                playerDeadL = true;
                Invoke("DeactivatePlayerDeadL", 2.0F);
            }
            if (gameObject.name == "Floor")
            {
                print("floor death");
                playerDead = true;
                Invoke("DeactivatePlayerDead", 2.0F);
            }
            if (gameObject.name == "Right")
            {
                print("right death");
                playerDeadR = true;
                Invoke("DeactivatePlayerDeadR", 2.0F);
            }
			other.transform.root.GetComponent<Manager>().Kill ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
            if (gameObject.name == "Left")
            {
                print("left death");
                playerDeadL = true;
                Invoke("DeactivatePlayerDeadL", 2.0F);
            }
            if (gameObject.name == "Floor")
            {
                print("floor death");
                playerDead = true;
                Invoke("DeactivatePlayerDead", 2.0F);
            }
            if (gameObject.name == "Right")
            {
                print("right death");
                playerDeadR = true;
                Invoke("DeactivatePlayerDeadR", 2.0F);
            }
			other.transform.root.GetComponent<Manager>().Kill ();
		}
	}

    //Functiont to deactivate playerDead
    void DeactivatePlayerDead()
    {
        playerDead = false;
    }

    //Functiont to deactivate playerDead
    void DeactivatePlayerDeadL()
    {
        playerDeadL = false;
    }

    //Functiont to deactivate playerDead
    void DeactivatePlayerDeadR()
    {
        playerDeadR = false;
    }
}
