using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public Transform player;
    public Transform bikePosition;
    public Transform walkPosition;

    public GameObject movement;

    public bool onBike = true;

    private void Start()
    {
        UpdatePlayer();
    }

    public void ToggleOnBike()
    {
        onBike = !onBike;
        UpdatePlayer();
        Debug.Log("switched bike state");
    }

    void UpdatePlayer()
    {
        if (onBike)
        {
            player.position = bikePosition.position;
            player.localRotation = Quaternion.identity;
            movement.SetActive(false);
        }
        else
        {
            player.position = walkPosition.position;
            movement.SetActive(true);
        }
    }
}
