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
    public GameObject PorteSortie;

    //Quand le joueur collide avec 1 item à ramasser
    private void OnTriggerEnter(Collider other)
    {
        //Si le joueur est devant la porte, alors qu'il n'a pas la clé pour,
        //un message s'affiche et si il a la clé, alors un autre message s'affiche,
        //le sprite "check" de la clé est appliqué dans l'inventaire et la porte est désactivée
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


        if (other.tag == "DoorExit")
        {
            if (CaseManager.KeyExit == false)
            {
                TextDisplaying.NoKeyExitBool = true;
            }
            if (CaseManager.KeyExit == true)
            {
                TextDisplaying.KeyExitBool = true;
                CaseManager.KeyExitCheck = true;
                PorteSortie.SetActive(false);
            }
        }
    }
}
