using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceManager : MonoBehaviour
{
    public Gate[] gates;
    public int laps;

    public int lap = 1;
    public bool raceStarted = false;

    public GameObject startUI;
    public float startTime;

    public InputActionReference resetPlayerPosition;
    public Transform player;

    public MovementControls movement;

    public TextMeshProUGUI personalBest;
    public TextMeshProUGUI previousTime;

    float pb = Mathf.Infinity;

    private void Start()
    {
        if(gates.Length == 0)
        {
            gates = FindObjectsOfType<Gate>();
            Array.Reverse(gates);
            Debug.Log(gates);
        }
    }

    private void Update()
    {
        if (raceStarted)
        {
            UpdateGates();
        }
        else
        {
            Countdown();
        }

        if (resetPlayerPosition.action.WasPressedThisFrame())
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {

        for(int i = 0; i<gates.Length; i++)
        {
            Gate currentGate = gates[i];
            Gate previousGate;

            if (i > 0)
            {
                previousGate = gates[i - 1];
            }
            else
            {
                previousGate = gates[i];
            }

            if (!currentGate.reached)
            {
                player.position = previousGate.transform.position;
                movement.ResetMovement(previousGate.transform.rotation.eulerAngles + new Vector3(0, 90, 0));
                break;
            }
        }
    }

    void Countdown()
    {
        if (gates[0].reached)
        {
            raceStarted = true;
            startUI.SetActive(false);
            startTime = Time.time;
        }
    }

    void UpdateGates()
    {
        int activeLeft = 2;
        bool allGatesReached = true;

        foreach (Gate gate in gates)
        {
            gate.particles.SetActive(!gate.reached && activeLeft > 0);

            if (!gate.reached)
            {
                activeLeft--;
                allGatesReached = false;
            }
        }

        if (allGatesReached)
        {

            foreach (Gate gate in gates)
            {
                gate.reached = false;
            }

            if (lap < laps)
            {
                lap++;
            }
            else
            {
                ResetRace();
            }
        }
    }

    void ResetRace()
    {
        lap = 1;
        raceStarted = false;
        startUI.SetActive(true);
        gates[0].particles.SetActive(true);
        movement.forwardThrust = 0;

        float finishTime = Time.time - startTime;

        previousTime.text = finishTime.ToString();

        if(finishTime < pb)
        {
            personalBest.text = finishTime.ToString();
            pb = finishTime;
        }
    }
}
