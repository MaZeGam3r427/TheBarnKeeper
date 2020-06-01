using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFixeEchelle : MonoBehaviour
{
    public GameObject Echelle;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Echelle.SetActive(false);
        }
    }
}
