using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public Transform potion1;
    private Vector3 pos1;
    public PotionEnd pots1;
    public Transform potion2;    
    private Vector3 pos2;
    public PotionEnd pots2;
    public Transform potion3;
    private Vector3 pos3;
    public PotionEnd pots3;
    public Transform potion4;
    private Vector3 pos4;
    public PotionEnd pots4;
    public Transform potion5;
    private Vector3 pos5;
    public PotionEnd pots5;
    public GameObject finpotion;

    public float speed;
    private Vector3 endposition;
    private Vector3 endposition1;
    private Vector3 endposition2;
    private Vector3 endposition3;
    private Vector3 endposition4;
    private Vector3 endposition5;
    private Vector3 currentpos;

    public ParticleSystem flash;
    public AudioSource audio;
    public AudioClip finmusic;
    public AudioClip flashmusic;
    private bool move;
    private bool potmove;

    public GameObject Credits;
    public GameObject Conclusion;
    public GameObject Thanks;
    public GameObject credit;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Win", 1);
        move = false;
        potmove = false;
        speed = 1;
        StartCoroutine("Pos1");
        potion1 = GameObject.Find("Pot1").GetComponent<Transform>();
        potion2 = GameObject.Find("Pot2").GetComponent<Transform>();
        potion3 = GameObject.Find("Pot3").GetComponent<Transform>();
        potion4 = GameObject.Find("Pot4").GetComponent<Transform>();
        potion5 = GameObject.Find("Pot5").GetComponent<Transform>();
        pots1 = GameObject.Find("Pot1").GetComponent<PotionEnd>();
        pots2 = GameObject.Find("Pot2").GetComponent<PotionEnd>();
        pots3 = GameObject.Find("Pot3").GetComponent<PotionEnd>();
        pots4 = GameObject.Find("Pot4").GetComponent<PotionEnd>();
        pots5 = GameObject.Find("Pot5").GetComponent<PotionEnd>();
    }

    public void Update()
    {
        currentpos = transform.position;
        pos1 = potion1.transform.position;
        pos2 = potion2.transform.position;
        pos3 = potion3.transform.position;
        pos4 = potion4.transform.position;
        pos5 = potion5.transform.position;

        if (move == true)
        gameObject.transform.position = Vector3.Lerp(currentpos, endposition, Time.deltaTime * speed);
        if (potmove == true)
        {
            potion1.position = Vector3.Lerp(pos1, endposition1, Time.deltaTime * speed);
            potion2.position = Vector3.Lerp(pos2, endposition2, Time.deltaTime * speed);
            potion3.position = Vector3.Lerp(pos3, endposition3, Time.deltaTime * speed);
            potion4.position = Vector3.Lerp(pos4, endposition4, Time.deltaTime * speed);
            potion5.position = Vector3.Lerp(pos5, endposition5, Time.deltaTime * speed);
        }  

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("step " + Time.time);
        }
    }
    IEnumerator Pos1()
    {
        yield return new WaitForSeconds(2);
        move = true;
        potmove = false;
        endposition = new Vector3(-10, transform.position.y, transform.position.z);
        StartCoroutine("Pos2");
    }
    IEnumerator Pos2()
    {
        potmove = false;
        yield return new WaitForSeconds(4f);
        potmove = true;
        endposition = new Vector3(transform.position.x, 35, transform.position.z);
        endposition1 = new Vector3(pos1.x, 33, pos1.z);
        endposition2 = new Vector3(pos2.x, 33, pos2.z);
        endposition3 = new Vector3(pos3.x, 33, pos3.z);
        endposition4 = new Vector3(pos4.x, 33, pos4.z);
        endposition5 = new Vector3(pos5.x, 33, pos5.z);
        StartCoroutine("Pos3");
    }    
    IEnumerator Pos3()
    {
        yield return new WaitForSeconds(2f);
        pots1.slow();
        pots2.slow();
        pots3.slow();
        pots4.slow();
        StartCoroutine("Pos4");
    }    
    IEnumerator Pos4()
    {
        yield return new WaitForSeconds(2);
        move = false;
        endposition1 = pos5;
        endposition2 = pos5;
        endposition3 = pos5;
        endposition4 = pos5;
        yield return new WaitForSeconds(1f);
        Debug.Log("Waited");
        flash.Play();
        pots1.end();
        pots2.end();
        pots3.end();
        pots4.end();
        pots5.end();
        finpotion.SetActive(true);
        audio.Stop();
        audio.clip = flashmusic;
        audio.Play();
        yield return new WaitForSeconds(1.2f);
        audio.Stop();
        audio.clip = finmusic;
        audio.Play();
        yield return new WaitForSeconds(3);
        StartCoroutine("Finish");
    }
    IEnumerator Finish()
    {
        Credits.SetActive(true);
        yield return new WaitForSeconds(8);
        Conclusion.SetActive(false);
        Thanks.SetActive(true);
        yield return new WaitForSeconds(8);
        Thanks.SetActive(false);
        credit.SetActive(true);
        AsyncOperation ao = SceneManager.LoadSceneAsync(0);
        ao.allowSceneActivation = false;
        yield return new WaitForSeconds(12);
        ao.allowSceneActivation = true;

    }

}