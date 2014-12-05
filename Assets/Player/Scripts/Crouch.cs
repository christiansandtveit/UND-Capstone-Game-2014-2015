//Christian Oliver Sandtveit
//CSci 492

using UnityEngine;
using System.Collections;

public class Crouch : MonoBehaviour
{

    private Transform transformPlayer;
    private float distanceToGround;

    // Use this for initialization
    void Start()
    {
        CharacterController player = GetComponent<CharacterController>();
        transformPlayer = transform;
        distanceToGround = player.height / 2;
    }

    // Update is called once per frame
    void Update()
    {

        float scale = 1.0f;

        if (Input.GetKey("c"))
        {
            scale = 0.5f;
        }
        float currentScale = transformPlayer.localScale.y;

        Vector3 temp = transformPlayer.localScale;
        Vector3 tempPos = transformPlayer.position;

        temp.y = Mathf.Lerp(transformPlayer.localScale.y, scale, 10 * Time.deltaTime);
        transformPlayer.localScale = temp;

        tempPos.y += distanceToGround * (transformPlayer.localScale.y - currentScale); // fix vertical position        
        transformPlayer.position = tempPos;
    }
}
