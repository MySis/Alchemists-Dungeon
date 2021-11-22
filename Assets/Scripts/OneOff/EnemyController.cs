using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Moving
    public Transform PlayerPos;
    public LayerMask player;
    public GameObject Fluff;

    private int Speed;
    private Vector3 StartPos;
    public bool Move;
    private bool returning;

    //Transforming
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Move = false;
        returning = false;
        Speed = 5;
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>();
        StartPos = transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
# region Enemy Moves to Player
        transform.LookAt(PlayerPos);

        if (Physics.CheckSphere(transform.position, 10f, player) && returning != true)
        {
            Move = true;
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }


        if (Move == true)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos, Speed * Time.deltaTime);
        }
        #endregion
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            StartCoroutine("Moveback");
            
        }
        if (collision.collider.CompareTag("Poly"))
        {
            Instantiate(Fluff, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            Move = true;
            animator.SetBool("Attack", true);
        }
    }
    IEnumerator Moveback()
    {
        Move = false;
        returning = true;
        animator.SetBool("Moving", true);
        transform.position = Vector3.MoveTowards(transform.position, StartPos, Speed * Time.deltaTime);
        yield return new WaitForSeconds(2);
        returning = false;
    }   
}
