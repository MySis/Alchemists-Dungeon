using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform win;
        

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(win);
    }
}
