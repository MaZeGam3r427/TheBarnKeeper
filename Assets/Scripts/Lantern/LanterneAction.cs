using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterneAction : MonoBehaviour
{
    public Animator myAnims;
    bool isLightning = false;
    float lanternCD = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && PlayerMovement.gotLantern && !isLightning)
        {
            myAnims.SetTrigger("LightUp");
            isLightning = true;
        }

        if(isLightning)
        {
            lanternCD -= Time.deltaTime;
        }

        if(lanternCD <= 0)
        {
            lanternCD = 2f;
            myAnims.SetTrigger("LightDown");
            isLightning = false;
        }
    }
}
