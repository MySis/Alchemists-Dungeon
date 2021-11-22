using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Image blueglow1;
    public Image whiteglow1;
    public Image blueglow2;
    public Image whiteglow2;    
    public GameObject LoadCanvas;
    public Slider slider;
    public float timepassed;
    public TextMeshProUGUI LoadText;

    private bool Fading = false;
    
    void Start()
    {
        StartCoroutine("LoadStart");        
    }

    void Update()
    {
        if (Fading == false)
            StartCoroutine("GlowScene");
        timepassed += Time.deltaTime;
        slider.value = timepassed;
    }

    IEnumerator LoadStart()
    {
        SetText();
        slider = GameObject.Find("LoadSlide").GetComponent<Slider>();
        slider.enabled = true;
        yield return new WaitForSeconds(30f);
        LoadCanvas.SetActive(false);
        slider.enabled = false;
    }
    IEnumerator GlowScene()
    {
        Fading = true;
        whiteglow1.CrossFadeAlpha(0, 0.5f, false);
        whiteglow2.CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        blueglow1.CrossFadeAlpha(0, 0.5f, false);
        blueglow2.CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(1f);
        blueglow1.CrossFadeAlpha(1, 0.5f, true);
        blueglow2.CrossFadeAlpha(1, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
        whiteglow1.CrossFadeAlpha(1, 0.5f, true);
        whiteglow2.CrossFadeAlpha(1, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
        Fading = false;
    }
    public void SetText()
    {
        string[] Fact = new string[] { "Default throw buttons are E for Acid and R for Normalize", "You can't throw acid at the creatures in the maze because they're actually Fairy Bunnies that a failed experiment transformed", "You're looking for ingredients, so you don't have to Normalize the Fairy Bunnies, but if you do it's probably good for your Karma (or something)" };
        string Factinfo = Fact[Random.Range(0, Fact.Length)];
        LoadText.text = Factinfo;
    }

}
