using UnityEngine;

public class DesWall : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Acid"))
            Destroy(gameObject);
    }
}
