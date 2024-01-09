using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool reached = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if(other.tag == "Player")
        {
            reached = true;
        }
    }
}
