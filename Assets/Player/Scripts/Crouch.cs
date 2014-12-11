//Christian Oliver Sandtveit
//CSci 492
/* A script which allows the character to crouch by pressing the buttons assigned to "Crouch" 
 Written by Christian Sandtveit, and modified by Darrin Winger to allow for controller support */

using UnityEngine;
using System.Collections;

public class Crouch : MonoBehaviour
{

    //Declare variables
    private Transform transformPlayer;
    private float distanceToGround;
    private float pace = 10;

    // Use this for initialization
    void Start()
    {
        CharacterController player = GetComponent<CharacterController>(); /*Needed to get height of player */
        transformPlayer = transform; /* Will allow me to modify players position and scale */
        distanceToGround = player.height / 2;
    }

    // Update is called once per frame
    void Update()
    {

        float scale = 1.0f; //Default scale of the player

        if (Input.GetButton("Crouch")) //If crouch button is pressed, the scale will be set to 1/2 of original
        {
            scale = 0.5f;
        }
        float currentScale = transformPlayer.localScale.y; //Get the current scale of the player

        /* Get the current localScale and position of player */
        Vector3 temp = transformPlayer.localScale; 
        Vector3 tempPos = transformPlayer.position;

        /* Change the current scale smoothly by using the Mathf.Lerp function, this will allow us to change the 
           pace at which the player crouch down or rise up by changing the pace variable. By changine the localScale
           we make sure that the collider shrinks, so that we can crouch under colliders if needed. */
        temp.y = Mathf.Lerp(transformPlayer.localScale.y, scale, pace * Time.deltaTime);
        transformPlayer.localScale = temp; 

        /* Change the position of the player */
        tempPos.y += distanceToGround * (transformPlayer.localScale.y - currentScale);      
        transformPlayer.position = tempPos;
    }
}
