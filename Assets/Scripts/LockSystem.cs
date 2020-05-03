using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockSystem : MonoBehaviour
{

    public GameObject StorageLockMinigame;

    public GameObject StorageLockSlot1;
    public GameObject StorageLockSlot2;
    public GameObject StorageLockSlot3;
    public GameObject StorageLockSlot4;


    public string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public char[] AlphabetArray;

    private void Start()
    {
        //StorageLockMinigame.SetActive(false);
        AlphabetArray = Alphabet.ToCharArray();
        print(AlphabetArray[0]); //A
        print(AlphabetArray[25]); //Z
        StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[10].ToString();
        StorageLockSlot2.GetComponent<TextMeshProUGUI>().text = AlphabetArray[24].ToString();
        StorageLockSlot3.GetComponent<TextMeshProUGUI>().text = AlphabetArray[18].ToString();
        StorageLockSlot4.GetComponent<TextMeshProUGUI>().text = AlphabetArray[3].ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LockStorage")
        {
            StorageLockMinigame.SetActive(true);
        }
    }

    public void StorageLockUpSlot1()
    {
        for (int i = 10; i < AlphabetArray.Length; i++)
        {
            StorageLockSlot1.GetComponent<TextMeshProUGUI>().text = AlphabetArray[i].ToString();
        }
    }


}
