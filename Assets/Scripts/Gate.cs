using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool reached = false;
    public AudioSource rewardSound;

    public GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && reached == false && particles.activeSelf)
        {
            reached = true;
            rewardSound.Play();
        }
    }
}
