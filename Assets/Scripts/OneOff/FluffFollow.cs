using UnityEngine;

public class FluffFollow : MonoBehaviour
{
    public Transform Player;
    public PlayerMove plyr;
    private int Speed;
    private int MinDist = 3;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 4;
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        plyr = GameObject.Find("Player").GetComponent<PlayerMove>();
        plyr.Rescue(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
            animator.SetBool("Moving", true);
        }
        else
            animator.SetBool("Moving", false);
    }
}
