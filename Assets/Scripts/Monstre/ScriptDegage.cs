using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptDegage : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float distance;
    public float radius = 3f;
    Animator BackToIDLE;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BackToIDLE.SetBool("isWalking", false);
            BackToIDLE.SetBool("isRuuning", false);
            agent.destination = target.position;
            agent.stoppingDistance = 3f;
            
        }
    }

}

