using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    public CharacterController controller;
    public Transform bike;

    public InputActionReference rightThrust;
    public InputActionReference leftThrust;

    public float thrustSpeed;
    public float dragSpeed;
    public float maxSpeed;

    public float turnAcceleration;
    public float turnDrag;
    public float maxTurnSpeed;

    Vector3 rotation = Vector3.zero;
    float turnSpeed = 0;
    float forwardThrust = 0;
    bool isThrusting = false;

    public enum TurnState
    {
        NotTurning,
        LeftTurn,
        RightTurn
    }

    public TurnState turnState;

    private void Start()
    {
        rotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTurn();
        CalculateThrust();

        controller.Move(transform.forward * forwardThrust * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(rotation);
    }

    void CalculateTurn()
    {
        float turn = 0;
        isThrusting = false;

        if (rightThrust.action.IsPressed())
        {
            turnState = TurnState.RightTurn;
            turn += turnAcceleration;
            isThrusting = true;
        }

        if (leftThrust.action.IsPressed())
        {
            turnState = TurnState.LeftTurn;
            turn -= turnAcceleration;
            isThrusting = true;
        }

        if (turn == 0)
        {
            turnState = TurnState.NotTurning;

            if(turnSpeed >= 0)
            {
                turnSpeed -= turnDrag * Time.deltaTime;
            }
            else
            {
                turnSpeed += turnDrag * Time.deltaTime;
            }

            if(turnSpeed>-0.1f && turnSpeed < 0.1f)
            {
                turnSpeed = 0;
            }
        }

        turnSpeed += turn * Time.deltaTime;
        turnSpeed = Mathf.Clamp(turnSpeed, -maxTurnSpeed, maxTurnSpeed);
        rotation.y += turnSpeed * Time.deltaTime;
    }

    void CalculateThrust()
    {
        if (isThrusting)
        {
            forwardThrust += thrustSpeed * Time.deltaTime;
        }
        else if (forwardThrust > 0)
        {
            forwardThrust -= dragSpeed * Time.deltaTime;
        }

        forwardThrust = Mathf.Clamp(forwardThrust, 0, maxSpeed);
    }
}
