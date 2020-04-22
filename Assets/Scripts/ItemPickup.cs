using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public CaseManager CaseManager;
    public TextDisplaying TextDisplaying;

    //Quand le joueur collide avec 1 item à ramasser,
    //Un bool correspondant à l'item est activé sur le script CaseManager
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Hammer")
        {
            CaseManager.Hammer = true;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Planks")
        {
            CaseManager.Planks = true;
            other.gameObject.SetActive(false);
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

        if (other.tag == "Ladder")
        {
            CaseManager.Ladder = true;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "KeyRemise")
        {
            CaseManager.KeyRemise = true;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "KeyLabo")
        {
            CaseManager.KeyLabo = true;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "MunLampe")
        {
            CaseManager.MunLampe = true;
            other.gameObject.SetActive(false);
        }
    }
}
