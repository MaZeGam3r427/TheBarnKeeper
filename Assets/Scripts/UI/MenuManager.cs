using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public LockSystem LockSystem;

    [Header("Inventory")]
    public static bool InventoryOpen = false;
    public GameObject InventoryUI; 
    public GameObject CursorIG;

    [Header("PauseMenu")]
    public static bool PauseOpen = false;
    public GameObject MenuPauseUI;
    public GameObject OptionsUI;

    [Header("LockStorage")]
    public static bool LockStorageOpen = false;
    public GameObject LockStorageUI;
    public GameObject ReturnGameStorage;

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
        if (PauseOpen == false && OptionsOpen == false  && Raycast.isReading == false && Input.GetKeyDown(KeyCode.Tab))
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

        if (InventoryOpen == false && OptionsOpen == false && Raycast.isReading == false && Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MenuPauseUI.SetActive(false);
        InventoryUI.SetActive(false);
        LockStorageUI.SetActive(false);
        ReturnGameStorage.SetActive(false);
        InventoryOpen = false;
        PauseOpen = false;
        LockStorageOpen = false;
        CursorIG.SetActive(true);

        if(PlayerMovement.gotLantern)
        {
            LanternUI.SetActive(true);
        }

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

    public void Replay()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
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

    public void Quit()
    {
        Application.Quit();
    }
}
