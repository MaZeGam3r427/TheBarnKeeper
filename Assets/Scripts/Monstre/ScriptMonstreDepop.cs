using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMonstreDepop : MonoBehaviour
{
    public GameObject Monstre;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Monstre.SetActive(false);
        }
    }
}
