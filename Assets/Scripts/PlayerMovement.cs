using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private bool touchingCollider = false;

    public Animator Myanim;


    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    private void Start()
    {
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (touchingCollider == true)
            {
                Myanim.SetTrigger("Climbing");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            touchingCollider = true;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            touchingCollider = false;
        }
    }*/

    public void TouchingColliderOff()
    {
        touchingCollider = false;
    }

}
