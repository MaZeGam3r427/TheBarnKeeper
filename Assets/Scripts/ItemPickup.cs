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

    //Quand le joueur collide avec 1 item à ramasser
    private void OnTriggerEnter(Collider other)
    {

        //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
        //+ l'objet est désactivé dans le jeu
        //+ un message s'affiche (cf : script TextDisplaying)
        if (other.tag == "Hammer")
        {
            CaseManager.Hammer = true;
            other.gameObject.SetActive(false);
            TextDisplaying.hammerBool = true;
        }

        //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
        //+ l'objet est désactivé dans le jeu
        //+ un message s'affiche (cf : script TextDisplaying)
        if (other.tag == "Planks")
        {
            CaseManager.Planks = true;
            other.gameObject.SetActive(false);
            TextDisplaying.planksBool = true;
        }

        //Quand le joueur est devant l'établi mais qu'il n'a pas les deux objets,
        //Un message s'affiche et si il a les deux objets, un autre message s'affiche
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

        //Si le joueur est devant l'échelle cassé alors qu'il n'a pas l'objet "échelle"
        //un message s'affiche et si il a l'objet "échelle", alors un autre message s'affiche,
        //l'échelle cassé est désactivée, l'échelle réparée est activée et le sprite "check"
        //de l'échelle est appliqué dans l'inventaire
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

        //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
        //+ l'objet est désactivé dans le jeu
        //+ un message s'affiche (cf : script TextDisplaying)
        if (other.tag == "KeyRemise")
        {
            CaseManager.KeyRemise = true;
            other.gameObject.SetActive(false);
            TextDisplaying.KeyRemiseTakenBool = true;
        }

        //Si le joueur est devant la porte, alors qu'il n'a pas la clé pour,
        //un message s'affiche et si il a la clé, alors un autre message s'affiche,
        //le sprite "check" de la clé est appliqué dans l'inventaire et la porte est désactivée
        if (other.tag == "DoorRemise")
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

        //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
        //+ l'objet est désactivé dans le jeu
        //+ un message s'affiche (cf : script TextDisplaying)
        if (other.tag == "KeyLabo")
        {
            CaseManager.KeyLabo = true;
            other.gameObject.SetActive(false);
            TextDisplaying.KeyLaboTakenBool = true;
        }

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

        if (other.tag == "MunLampe")
        {
            CaseManager.MunLampe = true;
            other.gameObject.SetActive(false);
        }
    }
}
