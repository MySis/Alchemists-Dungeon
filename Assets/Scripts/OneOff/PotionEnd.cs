using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEnd : MonoBehaviour
{
    public GameObject target;
    public float starttime;
    private bool spin;
    // Start is called before the first frame update
    void Start()
    {
        spin = false;
        starttime = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {
        if (spin == true)
        gameObject.transform.RotateAround(target.transform.position, Vector3.up, 60 * Time.deltaTime);
    }
    public void slow()
    {
        spin = true;
    }
    public void end()
    {
        Destroy(gameObject);
    }
}
