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

    public bool hasLantern;

    //public KeyCode _Key;
    //public Button _button;

    private void Awake()
    {
        //_button = GetComponent<Button>();
    }

    void Update()
    {
        //permet de remplire la barre d'huile sans dépaser de zéro a cent 
        oilBarImage.fillAmount = Oil / MaxOil;
        Oil = Mathf.Clamp(Oil, 0f, MaxOil);
        hasLantern = PlayerMovement.gotLantern;

        if(hasLantern)
        {
            Oil -= 1f * Time.deltaTime;
        }

        //Touche pour activer la lanterne et la consommation d'huile
        if(Input.GetKeyDown(KeyCode.A) && hasLantern)
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
            Oil = Oil + 10;
    }

}
