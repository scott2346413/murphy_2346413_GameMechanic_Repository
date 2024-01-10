using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public Transform bike;
    public float tiltAngle = 45f;
    public MovementControls movement;

    private float tilt;
    private Vector3 rotation;

    private void Start()
    {
        rotation = bike.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        switch(movement.turnState)
        {
            case MovementControls.TurnState.NotTurning:
                tilt = 0; break;
            case MovementControls.TurnState.RightTurn:
                tilt = -tiltAngle; break;
            case MovementControls.TurnState.LeftTurn:
                tilt = tiltAngle; break;
        }

        rotation.z = Mathf.Lerp(rotation.z, tilt, Time.deltaTime*0.5f);
        bike.localRotation = Quaternion.Euler(rotation);
    }
}
