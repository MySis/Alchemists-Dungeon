using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countfluff : MonoBehaviour
{

    public static countfluff instance;
    public int Lvlv1fluff;
    public int Lvlv2fluff;
    public int Lvlv3fluff;
    public int Lvlv4fluff;
    public int Lvlv5fluff;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    public void count1(int fluff)
    {
        if (fluff > Lvlv1fluff)
            Lvlv1fluff = fluff;
        PlayerPrefs.SetInt("Lvl1Fluffs", Lvlv1fluff);
    }
    public void count2(int fluff)
    {
        if (fluff > Lvlv2fluff)
            Lvlv2fluff = fluff;
        PlayerPrefs.SetInt("Lvl2Fluffs", Lvlv2fluff);
    }
    public void count3(int fluff)
    {
        if (fluff > Lvlv3fluff)
            Lvlv3fluff = fluff;
        PlayerPrefs.SetInt("Lvl3Fluffs", Lvlv3fluff);
    }
    public void count4(int fluff)
    {
        if (fluff > Lvlv4fluff)
            Lvlv4fluff = fluff;
        PlayerPrefs.SetInt("Lvl4Fluffs", Lvlv4fluff);
    }
    public void count5(int fluff)
    {
        if (fluff > Lvlv5fluff)
            Lvlv5fluff = fluff;
        PlayerPrefs.SetInt("Lvl5Fluffs", Lvlv5fluff);
    }
}
