using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptDetection : MonoBehaviour
{

    public Transform cible;//glisser l'objet player
    private Transform maTransform;
    private NavMeshAgent agent;
    public bool poursuite;
    public float pdv = 10f;
    public bool pause;

    public float PLS = 5f;
    public float Fine = 0f;

    void Awake()
    {
        maTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        Fine = PLS;

        //Initialisation du script NavMeshAgen qui se trouve sur le même objet que ce script
        agent = GetComponent<NavMeshAgent>();

        pause = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(pause == true)
        {
            Fine -= 1 * Time.deltaTime;
            agent.stoppingDistance = 1f;
        }

        if (Fine <= 0f)
        {
            pause = false;
            Fine = PLS;
            agent.stoppingDistance = 3f;
        }

        if (poursuite)
        {
            mouvement();
        }

        if (poursuite == false && pause == true)
        {
            miseEnAttente();
        }

    }


    private void mouvement()
    {
        //Si la variable "vieActuelle" est supérieur a 0
        if (pdv > 0)
        {
            Debug.DrawLine(cible.transform.position, maTransform.position, Color.blue);
            agent.destination = cible.position;//le squelette se dirige vers le joueur
        }
    }

    //L'ennemi reste a sa position actuelle
    private void miseEnAttente()
    {
        print("NE BOUGE PLUS !!");
        agent.destination = transform.position;
    }


}

