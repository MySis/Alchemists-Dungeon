using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerS : MonoBehaviour
{
    public AudioListener AL;
    public Slider slider;
    public Slider sliderturn;
    public float SlideValue;
    public void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
        slider.value = PlayerPrefs.GetFloat("Volume", 1);
        sliderturn.value = PlayerPrefs.GetFloat("TurnSpeed", 2);
    }
    public void Update()
    {
        AudioListener.volume = slider.value;        
    }
    public void VolumeSet()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 100);
        PlayerPrefs.SetFloat("TurnSpeed", sliderturn.value);
    }
    public void NextSelect()
    {
        Time.timeScale = 1;
        int Index = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadingScene(Index+1));
    }
    public void LevelSelect(int scene)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadingScene(scene));
    }
    IEnumerator LoadingScene(int scenenum)
    {
        yield return new WaitForSeconds(2);
        AsyncOperation ao = SceneManager.LoadSceneAsync(scenenum);
        ao.allowSceneActivation = false;
        yield return new WaitForSeconds(1);
        ao.allowSceneActivation = true;
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }
    
}


