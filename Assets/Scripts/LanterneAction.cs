using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterneAction : MonoBehaviour
{
    public Animator myAnims;
    public static bool isLighting = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isLighting)
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
