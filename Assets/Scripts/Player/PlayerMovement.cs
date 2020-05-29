using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    public CharacterController controller;
    public GameObject Player;


    [Header("Variables")]
    float climbTimer;
    bool isClimbing;
    bool canClimbing;
    bool canPick;
    bool isPickable;
    public static bool canWalk = true;
    bool LightOn = false;
    bool lookAt;
    public static bool useRaycast;
    public static bool isInteracting;
    [HideInInspector] public Raycast myRaycast;

    [Header("UI")]
    public GameObject ClimbText;
    public GameObject PickText;
    public GameObject InteractText;
    public GameObject UseText;
    public GameObject RepairText;
    public GameObject OpenText;
    public GameObject ReadText;
    public GameObject DeathScreenUI;

    [Header("Climbing")]
    public GameObject GroundPlow;
    public GameObject WallPlow;

    [Header("Stats")]
    public float speed = 12f;
    public float gravity = -9.81f;

    [Header("Lanterne")]
    public GameObject Lantern;
    public GameObject LanternUI;
    public GameObject PickableLantern;
    public static bool gotLantern;

    Vector3 velocity;

    private void Start()
    {
        useRaycast = true;
        myRaycast = GameObject.Find("VCam1").GetComponent<Raycast>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //LightOn = LanterneAction.isLighting;

        //if(LightOn == false)
        //{
        //    canWalk = true;
        //}
        //else
        //{
        //    canWalk = false;
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Si le joueur n'utilise pas la lanterne ou n'enjambe pas, il peut se déplacer
        if(canWalk)
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        PickText.SetActive(false);

        //Active la récupération de la lanterne et le texte associé si on la regarde
        if(Raycast.canPick)
        {
            CanPick();
        }
        //Désactive la récupération de la lanterne et le texte associé si on ne la regarde plus
        if (Raycast.canPick == false)
        {
            CanNotPick();
        }

        //Active l'interaction avec les objets spéciaux et le texte associé si on les regarde
        if(Raycast.canInteract == true)
        {
            DisplayText();
        }
        //Désactive l'interaction avec les objets spéciaux et le texte associé si on ne les regarde plus
        if (Raycast.canInteract == false)
        {
            HidingText();
        }

        if(Input.GetKeyDown(KeyCode.E) && canPick)
        {
            PickableLantern.SetActive(false);
            Lantern.SetActive(true);
            LanternUI.SetActive(true);
            PickText.SetActive(false);

            canPick = false;
            gotLantern = true;

            GroundPlow.SetActive(true);
            WallPlow.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && Raycast.canInteract== true)
        {
            isInteracting = true;
        }

        if(isInteracting)
        {
            FindObjectOfType<AudioManager>().Play("TakeSFX");
        }

    }

    void CanPick()
    {
        canPick = true;
        PickText.SetActive(true);
    }

    void CanNotPick()
    {
        canPick = false;
        PickText.SetActive(false);
    }

    void DisplayText()
    {
        if(Raycast.useEtabli == true)
        {
            UseText.SetActive(true);
        }

        if(Raycast.useLadder == true)
        {
            RepairText.SetActive(true);
        }

        if (Raycast.useCage == true || Raycast.useDoor == true)
        {
            OpenText.SetActive(true);
        }

        if(Raycast.isReading)
        {
            ReadText.SetActive(true);
        }

        if(Raycast.useObstacle == true)
        {
            ClimbText.SetActive(true);
        }

        if (!Raycast.useLadder && !Raycast.useEtabli && !Raycast.useCage
            && !Raycast.useObstacle && !Raycast.useDoor && !Raycast.isReading)
        {
            InteractText.SetActive(true);
        }
        
    }

    void HidingText()
    {
        ReadText.SetActive(false);
        ClimbText.SetActive(false);
        RepairText.SetActive(false);
        UseText.SetActive(false);
        InteractText.SetActive(false);
        OpenText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monstre"))
        {
            Debug.Log("touché");
            Time.timeScale = 0f;
            DeathScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
