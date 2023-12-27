using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    /*public float hoverHeight;
    public float hoverRange;
    public float hoverAcceleration;
    public float hoverMaxSpeed;

    public Transform bottomOfBike;*/

    public CharacterController controller;
    public float gravity = 9.8f;

    float verticalSpeed = 0;

    private void Update()
    {
        if (controller.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 move = Vector3.zero;    
        move.y = verticalSpeed;
        controller.Move(move*Time.deltaTime);
    }
}
