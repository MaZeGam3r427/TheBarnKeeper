using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCage : MonoBehaviour
{
    Animator CageAnims;
    public static bool staticIsOpen;
    bool isOpen;

    public GameObject OpenText;
    public GameObject CloseText;

    // Start is called before the first frame update
    void Start()
    {
        CageAnims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        staticIsOpen = isOpen;
        if (Raycast.useCage == true && PlayerMovement.isInteracting == true && isOpen == true)
        {
            CageAnims.SetTrigger("CloseDoor");
            isOpen = false;
            PlayerMovement.isInteracting = false;
        }

        else if(Raycast.useCage == false && PlayerMovement.isInteracting == false && isOpen == false)
        {
            CageAnims.SetTrigger("OpenDoor");
            isOpen = true;
            PlayerMovement.isInteracting = false;
        }
    }
}
