using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Inventory")]
    public static bool InventoryOpen = false;
    public GameObject InventoryUI; 
    public GameObject CursorIG;

    [Header("PauseMenu")]
    public static bool PauseOpen = false;
    public GameObject MenuPauseUI;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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

        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CursorIG.SetActive(false);
    }
}
