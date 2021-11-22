using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WanderFluff : MonoBehaviour
{
	public int speed;
    public bool Moving;
    private Animator animator;
    private Rigidbody rigidbody;
    private int secondsrange;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        Moving = false;
        Findtarget();
    }
    void Update()
    {        
        if(Moving==true)
            rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            StopAllCoroutines();
            Findtarget();
        }
            
    }
    IEnumerator Move()
    {
        secondsrange = Random.Range(0, 4);
        Moving = true;
        animator.SetBool("Moving", true);
        yield return new WaitForSeconds(secondsrange);
        Moving = false;
        animator.SetBool("Moving", false);
        yield return new WaitForSeconds(3);
        Findtarget();
    }
    void Findtarget()
    {
        int rotate = Random.Range(0, 360);
        transform.Rotate(Vector3.up, rotate);
        StartCoroutine("Move");
    }

}
