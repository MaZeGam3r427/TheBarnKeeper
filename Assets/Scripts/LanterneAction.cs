using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterneAction : MonoBehaviour
{
    public Animator myAnims;
    private bool isLighting = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isLighting)
        {
            myAnims.SetTrigger("ActiveMouvementLight");
            isLighting = true;
        }
        if (Input.GetKeyUp(KeyCode.A) && isLighting == true)
        {
            myAnims.SetTrigger("DeactivateLight");
            isLighting = false;
        }
    }
}
