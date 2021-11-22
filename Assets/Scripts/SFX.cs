using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.F))
            PlaySound();
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
