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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("RUN");
        }

        //else if (gameObject.CompareTag("Light"))
        //{
        //BackToIDLE.SetBool("isWalking", false);
        //BackToIDLE.SetBool("isRuuning", false);
        //agent.destination = target.position;
        //agent.stoppingDistance = 3f;
        //Debug.Log("Fuck");
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            Debug.Log("Worked");
        }
    }
}


