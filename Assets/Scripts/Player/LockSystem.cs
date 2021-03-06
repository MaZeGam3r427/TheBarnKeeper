﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockSystem : MonoBehaviour
{
    public Animator CageAnims;
    public Animator DrawerAnims;
    public GameObject StoreRoomLock;

    //objet à faire apparaitre/disparaitre
    public GameObject Locks;
    public GameObject LockStorageUI;
    public GameObject DesktopLockMinigame;
    public GameObject ReturnGameStorage;
    public GameObject ReturnGameDesktop;

    public GameObject LockStorageDoor;
    public GameObject LockDesktopDrawer;
    public GameObject UnlockDesktopDrawer;

    public GameObject Monstre;

    //Emplacements des lettres (gameobjects) et numéro de l'array (ints) pour la remise
    public GameObject StorageLockSlot1;
    private int LetterStorageLockSlot1 = 0;
    public GameObject StorageLockSlot2;
    private int LetterStorageLockSlot2 = 0;
    public GameObject StorageLockSlot3;
    private int LetterStorageLockSlot3 = 0;
    public GameObject StorageLockSlot4;
    private int LetterStorageLockSlot4 = 0;
    //
    //Emplacements des lettres (gameobjects) et numéro de l'array (ints) pour le bureau
    public GameObject DesktopLockSlot1;
    private int NumberDesktopLockSlot1 = 0;
    public GameObject DesktopLockSlot2;
    private int NumberDesktopLockSlot2 = 0;
    public GameObject DesktopLockSlot3;
    private int NumberDesktopLockSlot3 = 0;
    public GameObject DesktopLockSlot4;
    private int NumberDesktopLockSlot4 = 0;
    //


    private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private char[] AlphabetArray;

    private string Numbers = "0123456789";
    private char[] NumbersArray;

    private void Start()
    {
        Locks.SetActive(true);
        LockStorageUI.SetActive(false);
        DesktopLockMinigame.SetActive(false);

        ReturnGameStorage.SetActive(false);
        ReturnGameDesktop.SetActive(false);

        AlphabetArray = Alphabet.ToCharArray();
        LetterStorageLockSlot1 = 9;
        LetterStorageLockSlot2 = 21;
        LetterStorageLockSlot3 = 13;
        LetterStorageLockSlot4 = 7;
        StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot1].ToString();
        StorageLockSlot2.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot2].ToString();
        StorageLockSlot3.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot3].ToString();
        StorageLockSlot4.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot4].ToString();

        NumbersArray = Numbers.ToCharArray();
        NumberDesktopLockSlot1 = 7;
        NumberDesktopLockSlot2 = 3;
        NumberDesktopLockSlot3 = 0;
        NumberDesktopLockSlot4 = 5;
        DesktopLockSlot1.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot1].ToString();
        DesktopLockSlot2.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot2].ToString();
        DesktopLockSlot3.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot3].ToString();
        DesktopLockSlot4.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot4].ToString();
    }

    private void Update()
    {
        if(Raycast.useStorageLock == true)
        {
            LockStorageUIEnter();
        }

        if(Raycast.useDesktopLock == true)
        {
            LockDesktopUIEnter();
        }

        //Si on a la réponse de l'énigme de la remise
        if(StorageLockSlot1.GetComponent<TextMeshProUGUI>().text == AlphabetArray[3].ToString() &&
            StorageLockSlot2.GetComponent<TextMeshProUGUI>().text == AlphabetArray[4].ToString() &&
            StorageLockSlot3.GetComponent<TextMeshProUGUI>().text == AlphabetArray[0].ToString() &&
            StorageLockSlot4.GetComponent<TextMeshProUGUI>().text == AlphabetArray[3].ToString())
        {
            CageAnims.SetTrigger("Open");
            FindObjectOfType<AudioManager>().Play("DoorUnlock");
            //Monstre.SetActive(false);
        }

        //Si on a la réponse de l'énigme du bureau
        if (DesktopLockSlot1.GetComponent<TextMeshProUGUI>().text == NumbersArray[1].ToString() &&
            DesktopLockSlot2.GetComponent<TextMeshProUGUI>().text == NumbersArray[8].ToString() &&
            DesktopLockSlot3.GetComponent<TextMeshProUGUI>().text == NumbersArray[6].ToString() &&
            DesktopLockSlot4.GetComponent<TextMeshProUGUI>().text == NumbersArray[2].ToString())
        {
            DrawerAnims.SetBool("isOpen", true);
            DrawerAnims.gameObject.tag = "KeyExit";
            LockDesktopDrawer.SetActive(false);
            UnlockDesktopDrawer.SetActive(true);
            FindObjectOfType<AudioManager>().Play("DoorUnlock");
        }
    }

    public void LockStorageUIEnter()
    {
        LockStorageUI.SetActive(true);
        ReturnGameStorage.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LockDesktopUIEnter()
    {
        DesktopLockMinigame.SetActive(true);
        ReturnGameDesktop.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LockStorageUIExit()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        LockStorageUI.SetActive(false);
        ReturnGameStorage.SetActive(false);
        Raycast.useStorageLock = false;
    }

    public void LockDesktopUIExit()
    {
        DesktopLockMinigame.SetActive(false);
        ReturnGameDesktop.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Raycast.useDesktopLock = false;
    }

    //STORAGE
    //SLOT 1
    public void StorageLockUpSlot1()
    {
        if (LetterStorageLockSlot1 != 26)
        {
            LetterStorageLockSlot1 = LetterStorageLockSlot1 + 1;
            
            if (LetterStorageLockSlot1 == 26)
            {
                LetterStorageLockSlot1 = 0;
            }
            
            StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot1].ToString();
        }
    }

    public void StorageLockDownSlot1()
    {
        if (LetterStorageLockSlot1 != -1)
        {
            LetterStorageLockSlot1 = LetterStorageLockSlot1 - 1;

            if (LetterStorageLockSlot1 == -1)
            {
                LetterStorageLockSlot1 = 25;
            }

            StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot1].ToString();
        }
    }

    //SLOT 2
    public void StorageLockUpSlot2()
    {
        if (LetterStorageLockSlot2 != 26)
        {
            LetterStorageLockSlot2 = LetterStorageLockSlot2 + 1;

            if (LetterStorageLockSlot2 == 26)
            {
                LetterStorageLockSlot2 = 0;
            }

            StorageLockSlot2.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot2].ToString();
        }
    }

    public void StorageLockDownSlot2()
    {
        if (LetterStorageLockSlot2 != -1)
        {
            LetterStorageLockSlot2 = LetterStorageLockSlot2 - 1;

            if (LetterStorageLockSlot2 == -1)
            {
                LetterStorageLockSlot2 = 25;
            }

            StorageLockSlot2.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot2].ToString();
        }
    }

    //SLOT 3
    public void StorageLockUpSlot3()
    {
        if (LetterStorageLockSlot3 != 26)
        {
            LetterStorageLockSlot3 = LetterStorageLockSlot3 + 1;

            if (LetterStorageLockSlot3 == 26)
            {
                LetterStorageLockSlot3 = 0;
            }

            StorageLockSlot3.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot3].ToString();
        }
    }

    public void StorageLockDownSlot3()
    {
        if (LetterStorageLockSlot3 != -1)
        {
            LetterStorageLockSlot3 = LetterStorageLockSlot3 - 1;

            if (LetterStorageLockSlot3 == -1)
            {
                LetterStorageLockSlot3 = 25;
            }

            StorageLockSlot3.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot3].ToString();
        }
    }

    //SLOT 4
    public void StorageLockUpSlot4()
    {
        if (LetterStorageLockSlot4 != 26)
        {
            LetterStorageLockSlot4 = LetterStorageLockSlot4 + 1;

            if (LetterStorageLockSlot4 == 26)
            {
                LetterStorageLockSlot4 = 0;
            }

            StorageLockSlot4.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot4].ToString();
        }
    }

    public void StorageLockDownSlot4()
    {
        if (LetterStorageLockSlot4 != -1)
        {
            LetterStorageLockSlot4 = LetterStorageLockSlot4 - 1;

            if (LetterStorageLockSlot4 == -1)
            {
                LetterStorageLockSlot4 = 25;
            }

            StorageLockSlot4.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot4].ToString();
        }
    }








    //DESKTOP
    //SLOT1
    public void DesktopLockUpSlot1()
    {
        if (NumberDesktopLockSlot1 != 10)
        {
            NumberDesktopLockSlot1 = NumberDesktopLockSlot1 + 1;

            if (NumberDesktopLockSlot1 == 10)
            {
                NumberDesktopLockSlot1 = 0;
            }

            DesktopLockSlot1.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot1].ToString();
        }
    }

    public void DesktopLockDownSlot1()
    {
        if (NumberDesktopLockSlot1 != -1)
        {
            NumberDesktopLockSlot1 = NumberDesktopLockSlot1 - 1;

            if (NumberDesktopLockSlot1 == -1)
            {
                NumberDesktopLockSlot1 = 9;
            }

            DesktopLockSlot1.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot1].ToString();
        }
    }

    //SLOT 2
    public void DesktopLockUpSlot2()
    {
        if (NumberDesktopLockSlot2 != 10)
        {
            NumberDesktopLockSlot2 = NumberDesktopLockSlot2 + 1;

            if (NumberDesktopLockSlot2 == 10)
            {
                NumberDesktopLockSlot2 = 0;
            }

            DesktopLockSlot2.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot2].ToString();
        }
    }

    public void DesktopLockDownSlot2()
    {
        if (NumberDesktopLockSlot2 != -1)
        {
            NumberDesktopLockSlot2 = NumberDesktopLockSlot2 - 1;

            if (NumberDesktopLockSlot2 == -1)
            {
                NumberDesktopLockSlot2 = 9;
            }

            DesktopLockSlot2.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot2].ToString();
        }
    }

    //SLOT 3
    public void DesktopLockUpSlot3()
    {
        if (NumberDesktopLockSlot3 != 10)
        {
            NumberDesktopLockSlot3 = NumberDesktopLockSlot3 + 1;

            if (NumberDesktopLockSlot3 == 10)
            {
                NumberDesktopLockSlot3 = 0;
            }

            DesktopLockSlot3.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot3].ToString();
        }
    }

    public void DesktopLockDownSlot3()
    {
        if (NumberDesktopLockSlot3 != -1)
        {
            NumberDesktopLockSlot3 = NumberDesktopLockSlot3 - 1;

            if (NumberDesktopLockSlot3 == -1)
            {
                NumberDesktopLockSlot3 = 9;
            }

            DesktopLockSlot3.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot3].ToString();
        }
    }

    //SLOT 4
    public void DesktopLockUpSlot4()
    {
        if (NumberDesktopLockSlot4 != 10)
        {
            NumberDesktopLockSlot4 = NumberDesktopLockSlot4 + 1;

            if (NumberDesktopLockSlot4 == 10)
            {
                NumberDesktopLockSlot4 = 0;
            }

            DesktopLockSlot4.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot4].ToString();
        }
    }

    public void DesktopLockDownSlot4()
    {
        if (NumberDesktopLockSlot4 != -1)
        {
            NumberDesktopLockSlot4 = NumberDesktopLockSlot4 - 1;

            if (NumberDesktopLockSlot4 == -1)
            {
                NumberDesktopLockSlot4 = 9;
            }

            DesktopLockSlot4.GetComponent<TextMeshProUGUI>().text = NumbersArray[NumberDesktopLockSlot4].ToString();
        }
    }
}
