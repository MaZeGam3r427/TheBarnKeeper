using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public Transform Player;
    public bool inside = false;
    public float heightFactor = 3f;

    public bool Recule = false;

    private PlayerMovement CharacterControls;


    private void Start()
    {
        CharacterControls = GetComponent<PlayerMovement>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder")
        {
            CharacterControls.enabled = false;
            inside = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ladder")
        {
            CharacterControls.enabled = true;
            inside = false;
        }
    }



    private void Update()
    {
        if(inside == true && Input.GetKey(KeyCode.Z))
        {
            Player.transform.position += Vector3.up / heightFactor;
        }
        if(inside == true && Input.GetKey(KeyCode.S))
        {
            Player.transform.position += Vector3.down / heightFactor;
        }
    }
}
