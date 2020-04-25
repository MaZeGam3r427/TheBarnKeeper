using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaseManager : MonoBehaviour
{
    public TextMeshProUGUI InfoText;

    public Sprite SprHammer;
    public Sprite SprPlanks;
    public Sprite SprLadder;
    public Sprite SprKeyRemise;
    public Sprite SprKeyLabo;
    public Sprite MunitionsLampe;

    public Sprite SprHammerCheck;
    public Sprite SprPlanksCheck;
    public Sprite SprLadderCheck;
    public Sprite SprKeyRemiseCheck;
    public Sprite SprKeyLaboCheck;

    public bool Hammer = false;
    public bool Planks = false;
    public bool Ladder = false;
    public bool KeyRemise = false;
    public bool KeyLabo = false;
    public bool MunLampe = false;

    public bool HammerCheck = false;
    public bool PlanksCheck = false;
    public bool LadderCheck = false;
    public bool KeyRemiseCheck = false;
    public bool KeyLaboCheck = false;

    public GameObject CaseUne;
    public GameObject CaseDeux;
    public GameObject CaseTrois;
    public GameObject CaseQuatre;
    public GameObject CaseCinq;
    public GameObject CaseSix;

    

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
            //CaseQuatre.GetComponent<Image>().sprite = ;
        }

        if (KeyLabo == true)
        {
            //CaseCinq.GetComponent<Image>().sprite = ;
        }

        if (MunLampe == true)
        {
            //CaseSix.GetComponent<Image>().sprite = ;
        }

        //Quand les objets sont utilisés ils sont checked (sprite)
        if(HammerCheck == true)
        {
            CaseUne.GetComponent<Image>().sprite = SprHammerCheck;
        }

        if(PlanksCheck == true)
        {
            CaseDeux.GetComponent<Image>().sprite = SprPlanksCheck;
        }

        if(LadderCheck == true)
        {
            CaseTrois.GetComponent<Image>().sprite = SprLadderCheck;
        }
    }


    public void CaseMarteau()
    {
        if (Hammer == true)
        {
            InfoText.text = "A simple hammer that can help me create ladder steps with planks";
        }
    }

    public void CasePlanches()
    {
        if (Planks == true)
        {
            InfoText.text = "Some wooden planks that can be created into ladder steps";
        }
    }

    public void CaseEchelle()
    {
        if (Ladder == true)
        {
            InfoText.text = "Some ladder steps that i can put on the broken ladder";
        }
    }

    public void CaseCléRemise()
    {
        if (KeyRemise == true)
        {
            InfoText.text = "A key for the door at the ground floor";
        }
    }

    public void CaseCléLabo()
    {
        if (KeyLabo == true)
        {
            InfoText.text = "A key for the door at the second floor";
        }
    }

    public void CaseMunitionsLampe()
    {
        if (MunLampe == true)
        {
            //recharger la barre de munition
        }
    }
}
