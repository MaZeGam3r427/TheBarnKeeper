using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplaying : MonoBehaviour
{
    //texte quand on a pas assez de ressources pour construire l'échelle
    public GameObject TextNoRessource;
    //texte quand on a pas assez de ressources pour construire l'échelle
    public GameObject TextRessource;

    //texte quand on a pas l'objet échelle pour réparer l'échelle
    public GameObject TextLadderBroken;
    //texte quand on a réparé l'échelle
    public GameObject TextLadderFixed;

    //texte quand on a récupéré le marteau
    public GameObject TextHammer;
    //texte quand on a récupéré les planches
    public GameObject TextPlanks;

    //texte quand on a pas la clé pour la porte de la remise
    public GameObject TextNoKeyRemise;
    //texte quand on utilise la clé sur la porte de la remise
    public GameObject TextKeyRemise;
    //texte quand on récupère la clé de la remise
    public GameObject TextKeyRemiseTaken;

    //texte quand on a pas la clé pour la porte du labo
    public GameObject TextNoKeyLabo;
    //texte quand on utilise la clé sur la porte du labo
    public GameObject TextKeyLabo;
    //texte quand on récupère la clé du labo
    public GameObject TextKeyLaboTaken;

    public GameObject Etabli;

    public CaseManager CaseManager;


    public bool EtabliNoRessource = false;
    public bool EtabliRessource = false;
    public bool LadderBroken = false;
    public bool LadderFixed = false;
    public bool hammerBool = false;
    public bool planksBool = false;

    public bool NoKeyRemiseBool = false;
    public bool KeyRemiseBool = false;
    public bool KeyRemiseTakenBool = false;

    public bool NoKeyLaboBool = false;
    public bool KeyLaboBool = false;
    public bool KeyLaboTakenBool = false;

    public bool textDelay = true;

    private void Update()
    {
        if (EtabliNoRessource == true && textDelay == true)
        {
            textDelay = false;
            EtabliNoRessource = false;
            EtablietextNoRessources();
        }

        if(EtabliRessource == true && textDelay == true)
        {
            textDelay = false;
            EtabliRessource = false;
            CaseManager.HammerCheck = true;
            CaseManager.PlanksCheck = true;
            EtablietextRessources();
        }

        if (LadderBroken == true && textDelay == true)
        {
            textDelay = false;
            LadderBroken = false;
            LadderBrokenText();
        }

        if(LadderFixed == true && textDelay == true)
        {
            textDelay = false;
            LadderFixed = false;
            LadderFixedText();
        }

        if (hammerBool == true && textDelay == true)
        {
            textDelay = false;
            hammerBool = false;
            HammerText();
        }

        if(planksBool == true && textDelay == true)
        {
            textDelay = false;
            planksBool = false;
            PlanksText();
        }


        if (NoKeyRemiseBool == true && textDelay == true)
        {
            textDelay = false;
            NoKeyRemiseBool = false;
            NoKeyRemiseText();
        }

        if (KeyRemiseBool == true && textDelay == true)
        {
            textDelay = false;
            KeyRemiseBool = false;
            KeyRemiseText();
        }
        if(KeyRemiseTakenBool == true && textDelay == true)
        {
            textDelay = false;
            KeyRemiseTakenBool = false;
            KeyRemiseTakenText();
        }


        if (NoKeyLaboBool == true && textDelay == true)
        {
            textDelay = false;
            NoKeyLaboBool = false;
            NoKeyLaboText();
        }

        if (KeyLaboBool == true && textDelay == true)
        {
            textDelay = false;
            KeyLaboBool = false;
            KeyLaboText();
        }
        if (KeyLaboTakenBool == true && textDelay == true)
        {
            textDelay = false;
            KeyLaboTakenBool = false;
            KeyLaboTakenText();
        }
    }

    //Toutes les fonctions plus bas sont appellées dans Update pour chaques objets ramassés/interragit

    //Start Coroutine permet de faire une éxecution pendant un certain temps (affficher un texte dans ce cas là)
    //La plupart des IEnumerator est juste l'affichage d'un message, un délai en secondes et la désactivation du texte
    //La seule exception étant quand on s'approche de l'établi qui désactive son collider (pour éviter d'afficher le même message plein de fois)
    //et le réactive après sauf quand on a toutes les ressources (vu qu'on en a plus besoin)
    public void EtablietextNoRessources()
    {
        StartCoroutine(ShowMessageNoRessource(2));
    }

    IEnumerator ShowMessageNoRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextNoRessource.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoRessource.SetActive(false);
        Etabli.GetComponent<BoxCollider>().enabled = true;
        textDelay = true;
    }

    public void EtablietextRessources()
    {
        StartCoroutine(ShowMessageRessource(2));
    }

    IEnumerator ShowMessageRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextRessource.SetActive(true);
        CaseManager.Ladder = true;
        yield return new WaitForSeconds(delay);
        TextRessource.SetActive(false);
        textDelay = true;
    }

    public void LadderBrokenText()
    {
        StartCoroutine(ShowMessageLadderBroken(2));
    }

    IEnumerator ShowMessageLadderBroken(float delay)
    {
        TextLadderBroken.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextLadderBroken.SetActive(false);
        textDelay = true;
    }

    public void LadderFixedText()
    {
        StartCoroutine(ShowMessageLadderFixed(2));
    }

    IEnumerator ShowMessageLadderFixed(float delay)
    {
        TextLadderFixed.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextLadderFixed.SetActive(false);
        textDelay = true;
    }

    public void HammerText()
    {
        StartCoroutine(ShowMessageHammer(2));
    }

    IEnumerator ShowMessageHammer(float delay)
    {
        TextHammer.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextHammer.SetActive(false);
        textDelay = true;
    }

    public void PlanksText()
    {
        StartCoroutine(ShowMessagePlanks(2));
    }

    IEnumerator ShowMessagePlanks(float delay)
    {
        TextPlanks.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextPlanks.SetActive(false);
        textDelay = true;
    }


    public void NoKeyRemiseText()
    {
        StartCoroutine(ShowMessageNoKeyRemise(2));
    }
    IEnumerator ShowMessageNoKeyRemise(float delay)
    {
        TextNoKeyRemise.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoKeyRemise.SetActive(false);
        textDelay = true;
    }

    public void KeyRemiseText()
    {
        StartCoroutine(ShowMessageKeyRemise(2));
    }
    IEnumerator ShowMessageKeyRemise(float delay)
    {
        TextKeyRemise.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextKeyRemise.SetActive(false);
        textDelay = true;
    }

    public void KeyRemiseTakenText()
    {
        StartCoroutine(ShowMessageKeyRemiseTaken(2));
    }
    IEnumerator ShowMessageKeyRemiseTaken(float delay)
    {
        TextKeyRemiseTaken.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextKeyRemiseTaken.SetActive(false);
        textDelay = true;
    }


    public void NoKeyLaboText()
    {
        StartCoroutine(ShowMessageNoKeyLabo(2));
    }
    IEnumerator ShowMessageNoKeyLabo(float delay)
    {
        TextNoKeyLabo.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoKeyLabo.SetActive(false);
        textDelay = true;
    }

    public void KeyLaboText()
    {
        StartCoroutine(ShowMessageKeyLabo(2));
    }
    IEnumerator ShowMessageKeyLabo(float delay)
    {
        TextKeyLabo.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextKeyLabo.SetActive(false);
        textDelay = true;
    }

    public void KeyLaboTakenText()
    {
        StartCoroutine(ShowMessageKeyLaboTaken(2));
    }
    IEnumerator ShowMessageKeyLaboTaken(float delay)
    {
        TextKeyLaboTaken.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextKeyLaboTaken.SetActive(false);
        textDelay = true;
    }


}