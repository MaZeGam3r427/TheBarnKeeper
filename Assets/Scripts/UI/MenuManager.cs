using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Inventory")]
    public static bool InventoryOpen = false;
    public GameObject InventoryUI; 
    public GameObject CursorIG;

    [Header("PauseMenu")]
    public static bool PauseOpen = false;
    public GameObject MenuPauseUI;
    public GameObject OptionsUI;

    bool OptionsOpen;

    public Sprite OptionWindowed;
    public Sprite OptionFullscreen;

    public GameObject LanternUI;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseOpen == false && OptionsOpen == false && Input.GetKeyDown(KeyCode.Tab))
        {
            if(InventoryOpen)
            {
                Resume();
            }
            else
            {
                OpenInventory();
            }
        }

        if (InventoryOpen == false && OptionsOpen == false && Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseOpen)
            {
                Resume();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void Resume()
    {
        MenuPauseUI.SetActive(false);
        InventoryUI.SetActive(false);
        LanternUI.SetActive(true);
        Time.timeScale = 1f;
        InventoryOpen = false;
        PauseOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CursorIG.SetActive(true);

    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        InventoryOpen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CursorIG.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        PauseOpen = true;
        MenuPauseUI.SetActive(true);
        LanternUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CursorIG.SetActive(false);
    }

    public void Back()
    {
        OptionsOpen = false;
        OptionsUI.SetActive(false);
        MenuPauseUI.SetActive(true);
    }

    public void Options()
    {
        OptionsOpen = true;
        OptionsUI.SetActive(true);
        MenuPauseUI.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }


    public void Windowed()
    {
        Debug.Log("windowed");
        Screen.fullScreen = false;
        OptionsUI.GetComponent<Image>().sprite = OptionWindowed;
    }

    public void Fullscreen()
    {
        Debug.Log("fullscreen");
        Screen.fullScreen = true; 
        OptionsUI.GetComponent<Image>().sprite = OptionFullscreen;

    }
}
