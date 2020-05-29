using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilBar : MonoBehaviour
{
    public float Oil= 100f;
    public float MaxOil= 100f;
    public GameObject Light;
    public Image oilBarImage;

    bool hasLantern;

    void Update()
    {
        //Permet de remplire la barre d'huile sans dépaser de zéro a cent 
        oilBarImage.fillAmount = Oil / MaxOil;
        Oil = Mathf.Clamp(Oil, 0f, MaxOil);
        hasLantern = PlayerMovement.gotLantern;

        //Si la lanterne est récupérée, la quantité d'huile diminue petit à petit
        if(hasLantern)
        {
            Oil -= 1f * Time.deltaTime;
        }

        //Touche pour activer la lanterne et la consommation d'huile
        if(Input.GetKeyDown(KeyCode.A) && hasLantern)
        {
            Oil = Oil - 5;
        }

        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Oil -= 50;
        //}

        //permet de désactiver la lanterne lorsque la barre atteint zéro
        if (Oil <= 0)
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
        if(Raycast.Ammo > 0)
        {
            Oil = Oil + 50;
            Raycast.Ammo--;
        }   
    }

}
