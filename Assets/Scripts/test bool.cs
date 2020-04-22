using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbool : MonoBehaviour
{
    private bool IsReadyToLight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsReady ()
    {
        Debug.Log("hyppie");
        return IsReadyToLight;

    }
}
