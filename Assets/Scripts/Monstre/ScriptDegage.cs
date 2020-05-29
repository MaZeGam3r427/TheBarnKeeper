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
        activeObject = GameObject.Find("Monstre OBJ Riggé");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && activeObject == true)
        {

            agent.destination = target.position;
            agent.stoppingDistance = 3f;
            Debug.Log("Fuck");
            BackToIDLE.SetBool("isWalking", false);
            BackToIDLE.SetBool("isRuuning", false);
        }
    }
}


