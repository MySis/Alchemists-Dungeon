using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchFluff : MonoBehaviour
{
    public int Fluffcount;
    public GameObject Fluff;

    private void Start()
    {
        Fluffcount = PlayerPrefs.GetInt("Lvl1Fluffs") + PlayerPrefs.GetInt("Lvl2Fluffs") + PlayerPrefs.GetInt("Lvl3Fluffs") + PlayerPrefs.GetInt("Lvl4Fluffs") + PlayerPrefs.GetInt("Lvl5Fluffs");
        SpwnFluf(Fluffcount);
    }
    private void Update()
    {
    }
    void SpwnFluf(int FluffCount)
    {
        for (int i = 0; i < FluffCount; i++)
        {
            Instantiate(Fluff, new Vector3(Random.Range(-15, 15), 1, Random.Range(-10, 10)), transform.rotation);
        }
    }
}

