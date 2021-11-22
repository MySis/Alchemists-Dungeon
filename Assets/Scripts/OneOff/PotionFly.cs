using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionFly : MonoBehaviour
{
    public SFX sfx;    
    public void Update()
{
    transform.Translate(Vector3.forward * Time.deltaTime * 15);
}
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("Destroy");
    }
    IEnumerator Destroy()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.position = new Vector3(0, 0, -20);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        Debug.Log("Call Sound");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
