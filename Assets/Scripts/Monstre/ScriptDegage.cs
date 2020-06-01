using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptDegage : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float distance = 2f;
    public float radius = 3f;
    Animator BackToIDLE;
    public GameObject activeObject;

    private void Start()
    {
        activeObject = GameObject.FindWithTag("Monstre");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && activeObject == true)
        {
            Debug.Log("Marche");
            agent.destination = target.position;
            agent.stoppingDistance = 3f;
            BackToIDLE.SetBool("isWalking", false);
            BackToIDLE.SetBool("isRuuning", false);
            BackToIDLE.SetBool("isIdle", true);
        }
    }
}


