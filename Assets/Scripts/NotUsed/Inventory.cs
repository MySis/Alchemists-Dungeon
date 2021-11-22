using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Inventory : MonoBehaviour
{
    public PlayerMove player;
    public LoadManager loaded;

    public int Acid;
    public int Poly;
    public int Fluff;
    public int level;

    void Update()
    {
    }
    public void Acidup(int acid)
    {
        Acid = acid;
    }
    public void Polyup(int poly)
    {
        Poly = poly;
    }
    public void Fluffup(int fluff)
    {
        Fluff += fluff;
    }
    public void Lvlup(int lvl)
    {
        if (level < lvl)
            level = lvl;
    }
    public void Reset()
    {
        Acid=0;
        Poly = 0;
        Fluff = 0;
        level = 0;
    }
    public void Load()
    {
        //Acid = loaded.data.potionA;
    }
}
    
 
