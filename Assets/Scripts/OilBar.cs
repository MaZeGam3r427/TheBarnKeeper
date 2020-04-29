using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilBar : MonoBehaviour
{
    public float Oil= 75f;
    public float MaxOil= 100f;
    public GameObject Light;
    public Image oilBarImage;

    void Update()
    {
        //permet de remplire la barre d'huile sans dépaser de zéro a cent 
        oilBarImage.fillAmount = Oil / MaxOil;
        Oil = Mathf.Clamp(Oil, 0f, MaxOil);


        Oil -= 0.5f * Time.deltaTime;

        //Touche temporaire pour remplir la barre d'huile
        if(Input.GetKeyDown(KeyCode.E))
        {
            Oil = Oil + 10;
        }

        //Touche pour activer la lanterne et la consommation d'huile
        if(Input.GetKeyDown(KeyCode.A))
        {
            Oil = Oil - 10;
        }

        //permet de désactiver la lanterne lorsque la barre atteint zéro
        if (Oil == 0)
        {
            Light.SetActive(false);
        }
        else 
        {
            Light.SetActive(true);
        }
    }
    public void RechargeClick()
    {
        if (Input.GetButtonDown("Recharge"))
        {
            Oil = Oil + 10;
        }
    }
}
