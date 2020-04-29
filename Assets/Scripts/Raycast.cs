using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    bool useRayCast = true;
    public static bool isLooking = false;
    public static bool canPick = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    { 
        useRayCast = PlayerMovement.useRaycast;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //Bit shift the index of the layer (8) to geta bit mask
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, layerMask))
        {
            if(useRayCast == true)
            {
                if (hit.collider.gameObject.CompareTag("Obstacle"))
                {
                    isLooking = true;
                }
                else
                {
                    isLooking = false;
                }
            }
            else
            {
                isLooking = false;
                canPick = false;
            }
            
        }

        if(Physics.Raycast(transform.position, transform.forward, out hit, 0.75f, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Lanterne"))
            {
                canPick = true;
            }
            else
            {
                canPick = false;
            }
        }
    }
}
