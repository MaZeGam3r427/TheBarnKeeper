using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplaying : MonoBehaviour
{

    public GameObject TextNoRessource;

    public GameObject TextRessource;

    public CaseManager CaseManager;


    public bool EtabliNoRessource = false;
    public bool EtabliRessource = false;


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
    }

    public void EtablietextNoRessources()
    {
        StartCoroutine(ShowMessage(3));
    }

    IEnumerator ShowMessage(float delay)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        TextNoRessource.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoRessource.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    public void EtablietextRessources()
    {
        StartCoroutine(ShowLadder(3));
    }

    IEnumerator ShowLadder(float delay)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        TextRessource.SetActive(true);
        CaseManager.Ladder = true;
        yield return new WaitForSeconds(delay);
        TextRessource.SetActive(false);
    }
}