using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioSource engineSound;
    public MovementControls movementControls;

    private void Update()
    {
        engineSound.pitch = (movementControls.forwardThrust / 40) + 0.5f;
    }
}
