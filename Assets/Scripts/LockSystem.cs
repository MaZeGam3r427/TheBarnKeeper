using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockSystem : MonoBehaviour
{
    //objet où se trouve le script
    public GameObject StorageLockMinigame;

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


    public string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public char[] AlphabetArray;

    private void Start()
    {
        //StorageLockMinigame.SetActive(false);
        AlphabetArray = Alphabet.ToCharArray();
        LetterStorageLockSlot1 = 9;
        LetterStorageLockSlot2 = 21;
        LetterStorageLockSlot3 = 13;
        LetterStorageLockSlot4 = 7;
        StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot1].ToString();
        StorageLockSlot2.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot2].ToString();
        StorageLockSlot3.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot3].ToString();
        StorageLockSlot4.GetComponent<TextMeshProUGUI>().text = AlphabetArray[LetterStorageLockSlot4].ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LockStorage")
        {
            StorageLockMinigame.SetActive(true);
        }
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
}
