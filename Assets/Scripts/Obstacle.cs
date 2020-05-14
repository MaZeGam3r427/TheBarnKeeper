using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Obstacle : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCam2;
    public CinemachineVirtualCamera VirtualCam3;

    public GameObject CamMovment;
    public GameObject WayPoint1;
    public GameObject WayPoint2;
    public GameObject Player;

    public GameObject Lantern;

    bool lookAt;
    bool isClimbing;
    public static bool canClimbing;
    float climbTimer;
    int WayClimb = -1;


    //public GameObject ClimbText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(climbTimer);
       lookAt = Raycast.isLooking;
       //ClimbText.SetActive(false);



       //Augmente le timer si on enjambe l'obstalce
       if (isClimbing == true)
       {
           Lantern.SetActive(false);
           climbTimer += Time.deltaTime;
       }
       
       if(isClimbing == false)
       {
            if(PlayerMovement.gotLantern)
            {
                Lantern.SetActive(true);
                climbTimer = 0f;
            }
            else
            {
                climbTimer = 0f;
            }
       }

       ////Si le joueur observe l'obstacle, le joueur peut enjamber
       //if (lookAt)
       //{
       //    ActivateClimb();
       //}
       //else if(lookAt == false)
       //{
       //    DeactivateClimb();
       //}

       //Si on appuie sur E et que l'on peut enjamber l'obstacle
       if (canClimbing)
       {
           Player.gameObject.SetActive(false);
           CamMovment.GetComponent<CameraMovement>().enabled = false;
           PlayerMovement.canWalk = false;
           isClimbing = true;

           //Si l'on vient de la droite, change la priorité sur la première caméra
           if (WayClimb > 0)
           {
               VirtualCam3.Priority = 15;
           }
           //Sinon change la priorité sur la deuxième caméra
           else
           {
               VirtualCam2.Priority = 15;
           }

       }

       //if(climbTimer <= 0f && PlayerMovement.gotLantern)
       //{
       //    Lantern.SetActive(true);
       //}

       //Si le timer d'enjambement est plus grand que 0 et si l'on vient de la gauche
       if (climbTimer >= 1f && WayClimb > 0)
       {
           Player.transform.position = WayPoint2.transform.position;
           VirtualCam3.Priority = 5;
       }

       //Si le timer d'enjambement est plus petit que 0 et si l'on vient de la droite
       if (climbTimer >= 1f && WayClimb < 0)
       {
           Player.transform.position = WayPoint1.transform.position;
           VirtualCam2.Priority = 5;
       }

       //s'éxécute quand l'enjambement est fini
       if (climbTimer >= 2f)
       {
           Player.gameObject.SetActive(true);
           CamMovment.GetComponent<CameraMovement>().enabled = true;
           PlayerMovement.canWalk = true;
           isClimbing = false;

           if (WayClimb < 0)
           {
               WayClimb = 1;
           }
           else
           {
               WayClimb = -1;
           }
       }
    }

    //void ActivateClimb()
    //{
    //    canClimbing = true;
    //    ClimbText.SetActive(true);
    //}

    //void DeactivateClimb()
    //{
    //    canClimbing = false;
    //    ClimbText.SetActive(false);
    //}
}
