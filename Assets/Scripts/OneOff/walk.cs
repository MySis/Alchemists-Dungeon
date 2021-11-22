using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public float HzIn;
    public float VtIn;
    public Animator animator;
    public float Speed;
    public float TSpeed;

    public void Start()
    {
        TSpeed = PlayerPrefs.GetFloat("TurnSpeed", 2) + 1;
    }

    public void Update()
    {
        Speed = 3.5f;
        HzIn = Input.GetAxis("Horizontal");
        VtIn = Input.GetAxis("Vertical");
        float movespeed = Mathf.Abs(VtIn);
        animator.SetFloat("Speed", movespeed);

        transform.Translate(Vector3.forward * Speed * Time.deltaTime * VtIn);
        transform.Rotate(Vector3.up * TSpeed * 100 * Time.deltaTime * HzIn);
    }
}

