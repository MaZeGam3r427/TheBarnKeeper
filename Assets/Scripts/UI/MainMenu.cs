using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionMenuObj;
    public GameObject MainMenuObj;

    private void Start()
    {
        OptionMenuObj.SetActive(false);
    }

    //Menu Principal
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        OptionMenuObj.SetActive(true);
        MainMenuObj.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Menu Options
    public void BackMenu()
    {
        MainMenuObj.SetActive(true);
        OptionMenuObj.SetActive(false);
    }
}
