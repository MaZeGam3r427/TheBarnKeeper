using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptActivePop : MonoBehaviour
{
    public GameObject Parent;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Parent.SetActive(true);
        }
    }
}
