using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterneAction : MonoBehaviour
{
    public Animator myAnims;
    public static bool isLighting = false;
    float lanternCD;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lanternCD);
        if(lanternCD > 0)
        {
            lanternCD = -Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A) && !isLighting && lanternCD <= 0 && PlayerMovement.gotLantern)
        {
            myAnims.SetTrigger("ActivateLight");
            isLighting = true;
        }
        if (Input.GetKeyUp(KeyCode.A) && isLighting == true)
        {
            myAnims.SetTrigger("DeactivateLight");
            isLighting = false;
        }
    }
}
