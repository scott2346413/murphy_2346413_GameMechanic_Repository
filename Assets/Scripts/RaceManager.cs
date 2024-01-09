using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceManager : MonoBehaviour
{
    public Gate[] gates;
    public int laps;

    public int lap = 1;
    bool raceStarted = false;

    public TextMeshProUGUI countdown;
    public GameObject start;

    public InputActionReference resetPlayerPosition;
    public Transform player;

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
                player.rotation = previousGate.transform.rotation;
                break;
            }
        }
    }

    void Countdown()
    {
            countdown.text = (3 - ((int)Time.time)).ToString();

            if(Time.time > 4)
            {
                start.SetActive(false);
                raceStarted = true;
            }
    }

    void UpdateGates()
    {
        int activeLeft = 2;
        bool allGatesReached = true;

        foreach (Gate gate in gates)
        {
            gate.gameObject.SetActive(!gate.reached && activeLeft > 0);

            if (!gate.reached)
            {
                activeLeft--;
                allGatesReached = false;
            }
        }

        if (allGatesReached)
        {
            if (lap < laps)
            {
                foreach (Gate gate in gates)
                {
                    gate.reached = false;
                }

                lap++;
            }
            else
            {
                Debug.Log("race finish");
                //race finish
            }
        }
    }
}
