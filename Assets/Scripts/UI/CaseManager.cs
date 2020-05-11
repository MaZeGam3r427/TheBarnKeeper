using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaseManager : MonoBehaviour
{
    public TextMeshProUGUI InfoText;

    //sprites des objets
    public Sprite SprHammer;
    public Sprite SprPlanks;
    public Sprite SprLadder;
    public Sprite SprKeyRemise;
    public Sprite SprKeyLabo;
    public Sprite MunitionsLampe;


    //boolean pour chaques objets quand on les ramassent
    public bool Hammer = false;
    public bool Planks = false;
    public bool Ladder = false;
    public bool KeyRemise = false;
    public bool KeyLabo = false;
    public bool MunLampe = false;

    //boolean pour les objets quand il faut les check
    public bool HammerCheck = false;
    public bool PlanksCheck = false;
    public bool LadderCheck = false;
    public bool KeyRemiseCheck = false;
    public bool KeyLaboCheck = false;

    //Correspond à chaques cases de l'inventaire qui peuvent contenir un seul sprite à la fois
    public GameObject CaseUne;
    public GameObject CaseDeux;
    public GameObject CaseTrois;
    public GameObject CaseQuatre;
    public GameObject CaseCinq;
    public GameObject CaseSix;

    private bool textDelay = true;

    

    private void Update()
    {
        //Si un item a été activé par le biais du script ItemPickup,
        //alors on change le sprite de l'inventaire vide par un sprite approprié
        if (Hammer == true)
        {
            CaseUne.GetComponent<Image>().sprite = SprHammer;
            CaseUne.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }

        if (Planks == true)
        {
            CaseDeux.GetComponent<Image>().sprite = SprPlanks;
            CaseDeux.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }

        if (Ladder == true)
        {
            CaseTrois.GetComponent<Image>().sprite = SprLadder;
            CaseTrois.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }

        if (KeyRemise == true)
        {
            CaseQuatre.GetComponent<Image>().sprite = SprKeyRemise;
            CaseQuatre.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }

        if (KeyLabo == true)
        {
            CaseCinq.GetComponent<Image>().sprite = SprKeyLabo;
            CaseCinq.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }

        if (MunLampe == true)
        {
            //CaseSix.GetComponent<Image>().sprite = ;
        }

        //Quand les objets sont utilisés ils sont checked (sprite)
        if(HammerCheck == true)
        {
            CaseUne.GetComponent<Image>().sprite = null;
            CaseUne.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }

        if(PlanksCheck == true)
        {
            CaseDeux.GetComponent<Image>().sprite = null;
            CaseDeux.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }

        if(LadderCheck == true)
        {
            CaseTrois.GetComponent<Image>().sprite = null;
            CaseTrois.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }

        if(KeyRemiseCheck == true)
        {
            CaseQuatre.GetComponent<Image>().sprite = null;
            CaseQuatre.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }

        if (KeyLaboCheck == true)
        {
            CaseCinq.GetComponent<Image>().sprite = null;
            CaseCinq.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0f);
        }
    }

    //Texte que l'on retrouve dans l'inventaire quand on possède l'objet
    public void CaseMarteau()
    {
        if (HammerCheck == false && Hammer == true && textDelay == true)
        {
            textDelay = false;
            StartCoroutine(ShowHammerMessage(3));
        }
    }

    IEnumerator ShowHammerMessage(float delay)
    {
        InfoText.text = "A simple hammer that can help me create ladder steps with planks";
        yield return new WaitForSecondsRealtime(delay);
        InfoText.text = null;
        textDelay = true;
    }

    public void CasePlanches()
    {
        if (PlanksCheck == false && Planks == true && textDelay == true)
        {
            textDelay = false;
            StartCoroutine(ShowPlanchesMessage(3));
        }
    }
    IEnumerator ShowPlanchesMessage(float delay)
    {
        InfoText.text = "Some wooden planks that can be created into ladder steps";
        yield return new WaitForSecondsRealtime(delay);
        InfoText.text = null;
        textDelay = true;
    }

    public void CaseEchelle()
    {
        if (LadderCheck == false && Ladder == true && textDelay == true)
        {
            textDelay = false;
            StartCoroutine(ShowEchelleMessage(3));
        }
    }
    IEnumerator ShowEchelleMessage(float delay)
    {
        InfoText.text = "Some ladder steps that i can put on the broken ladder";
        yield return new WaitForSecondsRealtime(delay);
        InfoText.text = null;
        textDelay = true;
    }

    public void CaseCléRemise()
    {
        if (KeyRemiseCheck == false && KeyRemise == true && textDelay == true)
        {
            textDelay = false;
            StartCoroutine(ShowCléRemiseMessage(3));
        }
    }
    IEnumerator ShowCléRemiseMessage(float delay)
    {
        InfoText.text = "A key for the door at the ground floor";
        yield return new WaitForSecondsRealtime(delay);
        InfoText.text = null;
        textDelay = true;
    }

    public void CaseCléLabo()
    {
        if (KeyLaboCheck == false && KeyLabo == true && textDelay == true)
        {
            textDelay = false;
            StartCoroutine(ShowCléLaboMessage(3));
        }
    }
    IEnumerator ShowCléLaboMessage(float delay)
    {
        InfoText.text = "A key for the door at the second floor";
        yield return new WaitForSecondsRealtime(delay);
        InfoText.text = null;
        textDelay = true;
    }
    public void CaseMunitionsLampe()
    {
        if (MunLampe == true)
        {
            //recharger la barre de munition
        }
    }
}
