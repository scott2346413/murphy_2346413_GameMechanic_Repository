using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearWhenNeeded : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float fallHeight;
    public GameObject instructions;

    // Update is called once per frame
    void Update()
    {
        instructions.SetActive(player.position.y < fallHeight);

        instructions.transform.position = player.position + player.transform.forward * offset;
        instructions.transform.LookAt(player.position);
    }
}
