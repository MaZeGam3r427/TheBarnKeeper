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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        { 
            agent.destination = target.position;
            agent.stoppingDistance = 3f;
            
        }
    }

}

