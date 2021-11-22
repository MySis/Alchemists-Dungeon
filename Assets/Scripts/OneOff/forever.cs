using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forever : MonoBehaviour
{
    public GameObject Forever;

    private void Start()
    {
        Forever.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Forever.SetActive(true);
            PlayerPrefs.SetInt("Broke", 1);
        }
    }
}
