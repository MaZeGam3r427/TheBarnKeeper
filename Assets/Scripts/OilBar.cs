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
        oilBarImage.fillAmount = Oil / MaxOil;
        Oil = Mathf.Clamp(Oil, 0f, MaxOil);

        if(Input.GetKeyDown(KeyCode.E))
        {
            Oil = Oil + 10;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Oil = Oil - 10;
        }

        if (Oil == 0)
        {
            Light.SetActive(false);
        }
        else 
        {
            Light.SetActive(true);
        }
    }
}
