using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //Canvas
    public GameObject WASDTut;
    public GameObject NotWin;
    public GameObject DASHTut;
    public GameObject ACIDTut;
    public GameObject ENEMYTut;
    public GameObject WARNING;
    public GameObject POLYTut;
    public GameObject counts;
    public AudioSource audiosource;

    //Triggers
    public Transform door;
    public GameObject entrance;
    public GameObject wall;
    public GameObject acid;
    public Transform destwall;
    public GameObject enemytrig;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GameObject.Find("Tutorial").GetComponent<AudioSource>();
        StartCoroutine("Tutorial1");
    }
    private void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Trigger"))
        {
            StartCoroutine("Tutorial2");
        }
        if (collision.collider.CompareTag("Respawn"))
        {
            Destroy(acid);
            StartCoroutine("AcidTutorial");
        }
        if (collision.collider.CompareTag("MainCamera"))
        {
            Destroy(enemytrig);
            StartCoroutine("Polytutorial");
        }
    }

    IEnumerator Tutorial1()
    {
        yield return new WaitForSeconds(30);
        WASDTut.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(10);
        WASDTut.SetActive(false);
        DASHTut.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(7);
        DASHTut.SetActive(false);
    }
    IEnumerator Tutorial2()
    {
        NotWin.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(2);
        NotWin.SetActive(false);                
        wall.SetActive(false);
        entrance.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(3);
        counts.SetActive(true);
    }
    IEnumerator AcidTutorial()
    {           
        ACIDTut.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(7);
        ACIDTut.SetActive(false);
    }
    IEnumerator Polytutorial()
    {
        WARNING.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(3);
        WARNING.SetActive(false);
        ENEMYTut.SetActive(true);
        audiosource.Play();
        yield return new WaitForSeconds(4);
        ENEMYTut.SetActive(false);
        POLYTut.SetActive(true); 
        audiosource.Play();       
        yield return new WaitForSeconds(7);
        POLYTut.SetActive(false);
    }
}
