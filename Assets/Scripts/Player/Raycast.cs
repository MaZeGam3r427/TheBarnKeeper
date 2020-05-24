using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public CaseManager CaseManager;
    public TextDisplaying TextDisplaying;

    public GameObject LadderFixed;
    public GameObject KeyExit;
    public GameObject FirstAmmoText;
    public GameObject ColliderEnd;
    bool isOpen;

    public static int Ammo = 0;

    bool useRayCast = true;
    bool gotFirstAmmo;
    public static bool isLooking = false;
    public static bool canPick = false;
    public static bool canInteract = false;
    public static bool useEtabli;
    public static bool useLadder;
    public static bool useCage;
    public static bool useDoor;
    public static bool useObstacle;
    public static bool useStorageLock;
    public static bool useDesktopLock;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator DisplayFirstAmmoText(float time)
    {
        FirstAmmoText.SetActive(true);
        yield return new WaitForSecondsRealtime(time);
        FirstAmmoText.SetActive(false);
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


        if(Physics.Raycast(transform.position, transform.forward, out hit, 0.75f, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Lanterne"))
            {
                canPick = true;
            }

            if (hit.collider.gameObject.CompareTag("Planks") || hit.collider.gameObject.CompareTag("Hammer")
                || hit.collider.gameObject.CompareTag("Etabli") || hit.collider.gameObject.CompareTag("LadderBroken") 
                || hit.collider.gameObject.CompareTag("LockStorage") || hit.collider.gameObject.CompareTag("LockDesktop")
                || hit.collider.gameObject.CompareTag("Obstacle") || hit.collider.gameObject.CompareTag("KeyRemise")
                || hit.collider.gameObject.CompareTag("KeyLabo") || hit.collider.gameObject.CompareTag("KeyExit") 
                || hit.collider.gameObject.CompareTag("MunLampe") || hit.collider.gameObject.CompareTag("DoorRemise")
                || hit.collider.gameObject.CompareTag("DoorLabo") || hit.collider.gameObject.CompareTag("DoorExit")
                || hit.collider.gameObject.CompareTag("Drawer"))
            {
                canInteract = true;
                if(hit.collider.gameObject.CompareTag("MunLampe") && PlayerMovement.isInteracting)
                {
                    if (!gotFirstAmmo)
                    {
                        StartCoroutine(DisplayFirstAmmoText(3.5f));
                        gotFirstAmmo = true;
                    }
                    Ammo++;
                    hit.collider.gameObject.SetActive(false);
                    PlayerMovement.isInteracting = false;
                }

                if(hit.collider.gameObject.CompareTag("Drawer"))
                {
                    useDoor = true;
                    if(PlayerMovement.isInteracting)
                    {
                        Animator DrawerAnims = hit.collider.GetComponent<Animator>();
                        if(DrawerAnims.GetBool("isClosed") == false)
                        {
                            DrawerAnims.SetBool("isClosed", true);
                            PlayerMovement.isInteracting = false;
                        }
                        else
                        {
                            DrawerAnims.SetBool("isClosed", false);
                            PlayerMovement.isInteracting = false;
                        }
                    }
                }

                if (hit.collider.gameObject.CompareTag("KeyRemise") && PlayerMovement.isInteracting == true)
                {
                    CaseManager.KeyRemise = true;
                    hit.collider.gameObject.SetActive(false);
                    TextDisplaying.KeyRemiseTakenBool = true;
                    PlayerMovement.isInteracting = false;
                }

                if(hit.collider.gameObject.CompareTag("KeyExit") && PlayerMovement.isInteracting)
                {
                    CaseManager.KeyExit = true;
                    hit.collider.gameObject.tag = "Untagged";
                    KeyExit.SetActive(false);
                    TextDisplaying.KeyExitTakenBool = true;
                    PlayerMovement.isInteracting = false;
                }

                if (hit.collider.gameObject.CompareTag("DoorRemise") || hit.collider.gameObject.CompareTag("DoorLabo")
                    || hit.collider.gameObject.CompareTag("DoorExit"))
                {
                    useDoor = true;
                    {
                        if (PlayerMovement.isInteracting == true)
                        {
                            if (hit.collider.gameObject.CompareTag("DoorRemise"))
                            {
                                if (CaseManager.KeyRemise == false)
                                {
                                    TextDisplaying.NoKeyRemiseBool = true;
                                    PlayerMovement.isInteracting = false;
                                }
                                if (CaseManager.KeyRemise == true)
                                {
                                    TextDisplaying.KeyRemiseBool = true;
                                    CaseManager.KeyRemiseCheck = true;
                                    hit.collider.enabled = false;
                                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Open");
                                    PlayerMovement.isInteracting = false;
                                }
                            }

                            if (hit.collider.gameObject.CompareTag("DoorLabo"))
                            {
                                if (CaseManager.KeyLabo == false)
                                {
                                    TextDisplaying.NoKeyLaboBool = true;
                                    PlayerMovement.isInteracting = false;
                                }
                                if (CaseManager.KeyLabo == true)
                                {
                                    TextDisplaying.KeyLaboBool = true;
                                    CaseManager.KeyLaboCheck = true;
                                    hit.collider.enabled = false;
                                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Open");
                                    PlayerMovement.isInteracting = false;
                                }
                            }

                            if(hit.collider.gameObject.CompareTag("DoorExit"))
                            {
                                if(CaseManager.KeyExit == false)
                                {
                                    TextDisplaying.NoKeyExitBool = true;
                                    PlayerMovement.isInteracting = false;
                                }
                                else
                                {
                                    TextDisplaying.KeyExitBool = true;
                                    CaseManager.KeyExitCheck = true;
                                    hit.collider.enabled = false;
                                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Open");
                                    PlayerMovement.isInteracting = false;
                                    ColliderEnd.SetActive(true);
                                    StartCoroutine(SUCE());
                                }
                            }


                        }
                    }
                }   

                if (hit.collider.gameObject.CompareTag("KeyLabo") && PlayerMovement.isInteracting == true)
                {
                    CaseManager.KeyLabo = true;
                    hit.collider.gameObject.SetActive(false);
                    TextDisplaying.KeyLaboTakenBool = true;
                    PlayerMovement.isInteracting = false;

                }

                if (hit.collider.gameObject.CompareTag("Obstacle"))
                {
                    useObstacle = true;
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        hit.collider.gameObject.GetComponent<Obstacle>().enabled = true;
                        Obstacle.canClimbing = true;
                        PlayerMovement.isInteracting = false;
                    }
                    
                }

                //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
                //+ l'objet est désactivé dans le jeu
                //+ un message s'affiche (cf : script TextDisplaying)
                if (hit.collider.gameObject.CompareTag("Planks") && PlayerMovement.isInteracting == true)
                {
                    CaseManager.Planks = true;
                    hit.collider.gameObject.SetActive(false);
                    TextDisplaying.planksBool = true;
                    PlayerMovement.isInteracting = false;
                }

                //Le sprite de l'objet est affiché sur l'inventaire (cf : script CaseManager)
                //+ l'objet est désactivé dans le jeu
                //+ un message s'affiche (cf : script TextDisplaying)
                if (hit.collider.gameObject.CompareTag("Hammer") && PlayerMovement.isInteracting == true)
                {
                    CaseManager.Hammer = true;
                    hit.collider.gameObject.SetActive(false);
                    TextDisplaying.hammerBool = true;
                    PlayerMovement.isInteracting = false;
                }
                //Si le joueur regarde l'établi
                if (hit.collider.gameObject.CompareTag("Etabli"))
                {
                    useEtabli = true;
                    
                    //Lorsque le joueur appuie sur E, vérifie si il a les ressources nécessaires pour réparer l'échelle
                    if (PlayerMovement.isInteracting == true)
                    {
                        if (CaseManager.Hammer == false || CaseManager.Planks == false)
                        {
                            TextDisplaying.EtabliNoRessource = true;
                            PlayerMovement.isInteracting = false;
                            useEtabli = false;
                            canInteract = false;
                        }

                        if (CaseManager.Hammer == true && CaseManager.Planks == true)
                        {
                            TextDisplaying.EtabliRessource = true;
                            PlayerMovement.isInteracting = false;
                            hit.collider.enabled = false;
                            hit.collider.gameObject.tag = "Untagged";
                            useEtabli = false;
                            canInteract = false;
                        }
                    }
                }

                //Si le joueur est devant l'échelle cassé alors qu'il n'a pas l'objet "échelle"
                //un message s'affiche et si il a l'objet "échelle", alors un autre message s'affiche,
                //l'échelle cassé est désactivée, l'échelle réparée est activée et le sprite "check"
                //de l'échelle est appliqué dans l'inventaire
                if (hit.collider.gameObject.CompareTag("LadderBroken"))
                {
                    useLadder = true;

                    if (PlayerMovement.isInteracting == true)
                    {
                        if (CaseManager.Ladder == false)
                        {
                            TextDisplaying.LadderBroken = true;
                            PlayerMovement.isInteracting = false;
                        }
                        if (CaseManager.Ladder == true)
                        {
                            TextDisplaying.LadderFixed = true;
                            hit.collider.gameObject.SetActive(false);
                            LadderFixed.SetActive(true);
                            CaseManager.LadderCheck = true;
                            PlayerMovement.isInteracting = false;

                        }

                    }
                    
                }

                if(hit.collider.gameObject.CompareTag("LockStorage"))
                {
                    useCage = true;

                    if (PlayerMovement.isInteracting == true)
                    {
                        useStorageLock = true;
                        PlayerMovement.isInteracting = false;
                    }
                }

                if(hit.collider.gameObject.CompareTag("LockDesktop"))
                {
                    useCage = true;
                    {
                        if(PlayerMovement.isInteracting == true)
                        {
                            useDesktopLock = true;
                            PlayerMovement.isInteracting = false;
                        }
                    }
                }

            }
           
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, layerMask))
        {
            if (hit.collider.gameObject.tag != "Lanterne")
            {
                canPick = false;
            }

            if(hit.collider.gameObject.tag != "Planks" && hit.collider.gameObject.tag != "Hammer" 
                && hit.collider.gameObject.tag != "Etabli" && hit.collider.gameObject.tag != "LadderBroken"
                && hit.collider.gameObject.tag != "Obstacle" && hit.collider.gameObject.tag != "LockStorage"
                && hit.collider.gameObject.tag != "LockDesktop"&& hit.collider.gameObject.tag != "KeyRemise" 
                && hit.collider.gameObject.tag != "KeyLabo" && hit.collider.gameObject.tag != "KeyExit"
                && hit.collider.gameObject.tag != "DoorRemise" && hit.collider.gameObject.tag != "DoorLabo" 
                && hit.collider.gameObject.tag != "DoorExit" && hit.collider.gameObject.tag != "Drawer" 
                && hit.collider.gameObject.tag != "MunLampe")
            {
                Obstacle.canClimbing = false;
                useObstacle = false;
                isLooking = false;
                useLadder = false;
                useEtabli = false;
                useCage = false;
                useDoor = false;
                useStorageLock = false;
                canInteract = false;
            }
        }
    }

    IEnumerator SUCE()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("End");
    }
}
