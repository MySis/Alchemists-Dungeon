using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContinueScript : MonoBehaviour
{
    public int Lvl;    
    public Canvas LevelUI;
    public Canvas IntroCanvas;
    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject potion0;
    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;
    public GameObject potion4;
    public TextMeshProUGUI lvl1fluf;
    public TextMeshProUGUI lvl2fluf;
    public TextMeshProUGUI lvl3fluf;
    public TextMeshProUGUI lvl4fluf;
    public TextMeshProUGUI lvl5fluf;
    public GameObject Win;
    public GameObject Nfluff;
    public GameObject Afluff;
    public GameObject Broke;
    public countfluff count;

    // Start is called before the first frame update
    void Start()
    {
        LevelUI.enabled = false;
        Lvl = PlayerPrefs.GetInt("LevelNum");
        Debug.Log("Level continuescript" + Lvl);
        Potionshow(Lvl);
        Ach();
        if (Lvl < 3)
            StartCoroutine("Intro");
        lvl1fluf.text = (count.Lvlv1fluff + ("/2"));
        lvl2fluf.text = (count.Lvlv2fluff + ("/4"));
        lvl3fluf.text = (count.Lvlv3fluff + ("/7"));
        lvl4fluf.text = (count.Lvlv4fluff + ("/11"));
        lvl5fluf.text = (count.Lvlv5fluff + ("/14"));
        int TotalFluff = count.Lvlv1fluff + count.Lvlv2fluff + count.Lvlv3fluff + count.Lvlv4fluff + count.Lvlv5fluff;
        if (TotalFluff == 38)
            PlayerPrefs.SetInt("AllFluffs", 1);

    }

    // Update is called once per frame
    void OnCollisionEnter()
    {
        LevelUI.enabled = true;
        UIshow(Lvl);
    }
    IEnumerator Intro()
    {
        IntroCanvas.enabled = true;
        yield return new WaitForSeconds(10);
        IntroCanvas.enabled = false;
    }
    public void Ach()
    {

        int winach = PlayerPrefs.GetInt("Win");
        int nflufach = PlayerPrefs.GetInt("NoFluffs");
        int aflufach = PlayerPrefs.GetInt("AllFluffs");
        int broke = PlayerPrefs.GetInt("Broke");


        if (winach == 1)
            Win.SetActive(true);
        if (nflufach == 1)
        {
            Debug.Log("NO FLUFFS");
            Nfluff.SetActive(true);
        }
        if (aflufach == 1)
            Afluff.SetActive(true);
        if (broke == 1)
            Broke.SetActive(true);

    }
    void Potionshow(int lvls)
    {
        if (lvls >= 2)
        {            
            potion0.SetActive(true);
            potion1.SetActive(false);
            potion2.SetActive(false);
            potion3.SetActive(false);
            potion4.SetActive(false);
        }
        else if (lvls >= 3)
        {
            potion0.SetActive(true);
            potion1.SetActive(true);
            potion2.SetActive(false);
            potion3.SetActive(false);
            potion4.SetActive(false);
        }
        else if (lvls >= 4)
        {
            potion0.SetActive(true);
            potion1.SetActive(true);
            potion2.SetActive(true);
            potion3.SetActive(false);
            potion4.SetActive(false);
        }
        else if (lvls >= 5)
        {
            potion0.SetActive(true);
            potion1.SetActive(true);
            potion2.SetActive(true);
            potion3.SetActive(true);
            potion4.SetActive(false);
        }
        else if (lvls >=6)
        {
            potion0.SetActive(true);
            potion1.SetActive(true);
            potion2.SetActive(true);
            potion3.SetActive(true);
            potion4.SetActive(true);
        }
    }

    void UIshow(int lvls)
    {
        if (lvls == 0)
        {
            button0.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else if (lvls == 2)
        {
            button0.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else if (lvls == 3)
        {
            button0.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else if (lvls == 4)
        {
            button0.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(false);
        }
        else if (lvls == 5)
        {
            button0.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(true);
        }
    }
}
