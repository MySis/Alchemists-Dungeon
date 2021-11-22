using UnityEngine;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;

    public PlayerMove player;
    public int Acids;
    public int Polys;
    public int Fluffs;
    public int Level;

    public bool LoadGame;
    public Button GameLoad;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        Load();
    }

    public void Update()
    {
        if (LoadGame == true)
            GameLoad.GetComponent<Button>().interactable = true;
        else
            GameLoad.GetComponent<Button>().interactable = false; 
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            LoadGame = true;
            Acids = PlayerPrefs.GetInt("Acids", 0);
            Polys = PlayerPrefs.GetInt("Polys", 0);
            Fluffs = PlayerPrefs.GetInt("Fluffs", 0);
            Level = PlayerPrefs.GetInt("Level", 0);

        /*    player.SetAcids(Acids);
            player.SetPolys(Polys);
            player.SetFluffs(Fluffs);
            player.SetLevl(Level);*/

        }
        else
            LoadGame = false;
    }
    public void Save()
    {
        Debug.Log("Running Save");
        Acids = player.Acids;
        Polys = player.Polys;
        Fluffs = player.Fluffs;
        Level = player.level;
        SetSave();
    }
    public void SetSave()
    {
        Debug.Log("Saving Info");
        PlayerPrefs.SetInt("Acids", Acids);
        PlayerPrefs.SetInt("Polys", Polys);
        PlayerPrefs.SetInt("Fluffs", Fluffs);
        PlayerPrefs.SetInt("Level", Level);
    }
}