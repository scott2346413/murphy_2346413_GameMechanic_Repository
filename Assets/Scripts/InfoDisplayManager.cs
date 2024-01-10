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
        raceManager = FindObjectOfType<RaceManager>();
    }

    private void Update()
    {
        infoDisplay.text = "Lap " + raceManager.lap + "/" + raceManager.laps + "\n" + "Speed " + movement.forwardThrust + "\n" + "Time " + Mathf.Clamp((Time.time - 4), 0, Mathf.Infinity).ToString();
    }
}
