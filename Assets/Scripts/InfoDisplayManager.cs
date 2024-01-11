using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoDisplayManager : MonoBehaviour
{
    public MovementControls movement;
    public RaceManager raceManager;

    public TextMeshProUGUI infoDisplay;

    private void Start()
    {
        if (raceManager == null)
        {
            raceManager = FindObjectOfType<RaceManager>();
        }
    }

    private void Update()
    {
        if (raceManager.raceStarted)
        {
            infoDisplay.text = "Lap " + raceManager.lap + "/" + raceManager.laps + "\n" + "Speed " + movement.forwardThrust + "\n" + "Time " + (Time.time - raceManager.startTime).ToString();
        }
        else
        {
            infoDisplay.text = "Waiting to Start \n --- \n Speed " + movement.forwardThrust;
        }
    }
}
