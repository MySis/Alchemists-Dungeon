using UnityEngine;

public class ColDes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }

}
