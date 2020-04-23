using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplaying : MonoBehaviour
{

    public GameObject TextNoRessource;

    public GameObject TextRessource;

    public GameObject TextHammer;
    public GameObject TextPlanks;

    public GameObject Etabli;

    public CaseManager CaseManager;


    public bool EtabliNoRessource = false;
    public bool EtabliRessource = false;
    public bool hammerBool = false;
    public bool planksBool = false;


    private void Update()
    {
        if (EtabliNoRessource == true)
        {
            EtabliNoRessource = false;
            EtablietextNoRessources();
        }

        if(EtabliRessource == true)
        {
            EtabliRessource = false;
            CaseManager.HammerCheck = true;
            CaseManager.PlanksCheck = true;
            EtablietextRessources();
        }

        if(hammerBool == true)
        {
            hammerBool = false;
            HammerText();
        }

        if(planksBool == true)
        {
            planksBool = false;
            PlanksText();
        }
    }

    public void EtablietextNoRessources()
    {
        StartCoroutine(ShowMessageNoRessource(3));
    }

    IEnumerator ShowMessageNoRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextNoRessource.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoRessource.SetActive(false);
        Etabli.GetComponent<BoxCollider>().enabled = true;
    }

    public void EtablietextRessources()
    {
        StartCoroutine(ShowMessageRessource(3));
    }

    IEnumerator ShowMessageRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextRessource.SetActive(true);
        CaseManager.Ladder = true;
        yield return new WaitForSeconds(delay);
        TextRessource.SetActive(false);
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
    }
}