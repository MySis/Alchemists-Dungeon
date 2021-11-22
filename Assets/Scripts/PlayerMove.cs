using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    #region variables
    public float Speed;
    private float TSpeed;
    public Rigidbody rbplayer;
    public Vector3 PlyrPos;
    private Quaternion PlyrRot;

    //potions
    public GameObject potiona;
    public GameObject potionp;
    public GameObject PotionSpawn;

    private Animator animator;
    public bool gameover;
    public GameObject Finish;
    public Canvas dead;
    public Image death;

    public int level;
    public int Acids;
    public int Polys;
    public int Fluffs;
    private bool throwing;

    public float HzIn;
    public float VtIn;

    public AudioSource audio;
    public AudioClip winmusic;
    public AudioClip diemusic;

    public TextMeshProUGUI acidcount;
    public TextMeshProUGUI polycount;

    public countfluff count;

    #endregion
    void Start()
    {

        Load();
        SetTSpeed();
        gameover = false;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Dead", false);
    }
#region movement
    void FixedUpdate()
    {
        acidcount.text = (" "+Acids);
        polycount.text = (" " + Polys);
 
        HzIn = Input.GetAxis("Horizontal");
        VtIn = Input.GetAxis("Vertical");
        float movespeed = Mathf.Abs(VtIn);
        animator.SetFloat("Speed", movespeed);

        if (gameover == false)
        {
            rbplayer.AddForce(transform.forward * (Speed*VtIn), ForceMode.Acceleration);
            //transform.Translate(Vector3.forward * Speed * Time.deltaTime * VtIn);
            transform.Rotate(Vector3.up * (TSpeed * 50) * Time.deltaTime * HzIn);
        }

        PlyrPos = transform.position;
        PlyrRot = transform.rotation;
        if (Input.GetKey(KeyCode.LeftShift) && VtIn > 0)
        {
            animator.SetBool("Sprint", true);
            Speed = 60f;
        }
        else if (Input.GetKey(KeyCode.RightShift) && VtIn > 0)
        {
            animator.SetBool("Sprint", true);
            Speed = 60f;
        }
        else
        {
            animator.SetBool("Sprint", false);
            Speed = 30f;
        }
        #region Throwing
        if (throwing != true)
        {
            if (Input.GetAxis("Acid") > 0 && Acids > 0)
            {
                StartCoroutine(ThrowAcid());
                Acids--;
                throwing = true;
            }
            if (Input.GetAxis("Poly") > 0 && Acids > 0)
            {
                StartCoroutine(ThrowPoly());
                Polys--;
                throwing = true;
            }
        }
        #endregion
    }
    private IEnumerator ThrowAcid()
    {
        animator.SetTrigger("Throw");
        yield return new WaitForSeconds(0.5f);
        Instantiate(potiona, (PotionSpawn.transform.position), PlyrRot);
        throwing = false;
    }
    private IEnumerator ThrowPoly()
    {
        animator.SetTrigger("Throw");
        yield return new WaitForSeconds(0.5f);
        Instantiate(potionp, (PotionSpawn.transform.position), PlyrRot);
        throwing = false;
    }
    #endregion
   #region Collisions
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameover != true)
                GameOver();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Finish.SetActive(true);
            Win();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Acid") | other.gameObject.CompareTag("Poly"))
        {
            {
                if (other.gameObject.CompareTag("Acid"))
                {
                    Acids++;
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.CompareTag("Poly"))
                {
                    Polys++;
                    Destroy(other.gameObject);
                }
            }
        }
    }
    #endregion
    public void SetTSpeed()
    {
        TSpeed = (PlayerPrefs.GetFloat("TurnSpeed", 2)) + 1;
    }
    public void Rescue(int fluff)
    {
        Fluffs += fluff;
    }

    public void RestartGame()
    {
        Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Win()
    {
        gameover = true;
        audio.Stop();
        audio.clip = winmusic;
        audio.loop = false;
        audio.Play();
        int Index = SceneManager.GetActiveScene().buildIndex;
        if (level <= Index)
            level = Index;
        Save();
    }
    public void GameOver()
    {
        dead = GameObject.Find("GameOver").GetComponent<Canvas>();
        death = GameObject.Find("dead").GetComponent<Image>();
        dead.enabled = true;
        death.canvasRenderer.SetAlpha(0f);
        death.CrossFadeAlpha(1, 5.0f, false);
        animator.SetTrigger("Dead");
        gameover = true;

        audio.Stop();
        audio.clip = diemusic;
        audio.Play();
    }
    public void Save()            
    {
        Debug.Log("Saving Info");
        PlayerPrefs.SetInt("Acids", Acids);
        PlayerPrefs.SetInt("Polys", Polys);
        PlayerPrefs.SetInt("LevelNum", level);
        if (Fluffs == 0)
            PlayerPrefs.SetInt("NoFluffs", 1);
        else if (level == 2)
            count.count1(Fluffs);
        else if (level == 3)
            count.count2(Fluffs);
        else if (level == 4)
            count.count3(Fluffs);
        else if (level == 5)
            count.count4(Fluffs);
        else if (level == 6)
            count.count5(Fluffs);
        Debug.Log("Level " + level);
        Debug.Log("Saved");
    }
    public void Load()
    {
        Debug.Log("Loading");
        Acids = PlayerPrefs.GetInt("Acids");
        Polys = PlayerPrefs.GetInt("Polys");
        level = PlayerPrefs.GetInt("LevelNum");
        Debug.Log("Loaded");
        Debug.Log("Level " + level);
    }
}


