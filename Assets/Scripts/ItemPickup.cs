using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public CaseManager CaseManager;
    public TextDisplaying TextDisplaying;

    public GameObject LadderFixed;

    public GameObject PorteRemise;
    public GameObject PorteLabo;

    //Quand le joueur collide avec 1 item à ramasser,
    //Un bool correspondant à l'item est activé sur le script CaseManager
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Hammer")
        {
            CaseManager.Hammer = true;
            other.gameObject.SetActive(false);
            TextDisplaying.hammerBool = true;
        }

        if (other.tag == "Planks")
        {
            CaseManager.Planks = true;
            other.gameObject.SetActive(false);
            TextDisplaying.planksBool = true;
        }

        if (other.tag == "Etabli")
        {
            if (CaseManager.Hammer == false || CaseManager.Planks == false)
            {
                TextDisplaying.EtabliNoRessource = true;
            }
            
            if (CaseManager.Hammer == true && CaseManager.Planks == true)
            {
                TextDisplaying.EtabliRessource = true;
            }
        }

        if (other.tag == "LadderBroken")
        {
            if (CaseManager.Ladder == false)
            {
                TextDisplaying.LadderBroken = true;
            }
            if(CaseManager.Ladder == true)
            {
                TextDisplaying.LadderFixed = true;
                other.gameObject.SetActive(false);
                LadderFixed.SetActive(true);
                CaseManager.LadderCheck = true;

            }
        }

        if (other.tag == "KeyRemise")
        {
            CaseManager.KeyRemise = true;
            other.gameObject.SetActive(false);
            TextDisplaying.KeyRemiseTakenBool = true;
        }

        if(other.tag == "DoorRemise")
        {
            if(CaseManager.KeyRemise == false)
            {
                TextDisplaying.NoKeyRemiseBool = true;
            }
            if (CaseManager.KeyRemise == true)
            {
                TextDisplaying.KeyRemiseBool = true;
                CaseManager.KeyRemiseCheck = true;
                PorteRemise.SetActive(false);
            }
        }

        if (other.tag == "KeyLabo")
        {
            CaseManager.KeyLabo = true;
            other.gameObject.SetActive(false);
            TextDisplaying.KeyLaboTakenBool = true;
        }

        if (other.tag == "DoorLabo")
        {
            if (CaseManager.KeyLabo == false)
            {
                TextDisplaying.NoKeyLaboBool = true;
            }
            if (CaseManager.KeyLabo == true)
            {
                TextDisplaying.KeyLaboBool = true;
                CaseManager.KeyLaboCheck = true;
                PorteLabo.SetActive(false);
            }
        }

        if (other.tag == "MunLampe")
        {
            CaseManager.MunLampe = true;
            other.gameObject.SetActive(false);
        }
    }
}
