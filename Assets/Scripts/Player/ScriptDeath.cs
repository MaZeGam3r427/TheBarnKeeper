using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeath : MonoBehaviour
{
    public GameObject DeathScreenUI;
    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.name == "Group7952")
        {
            gameObject.SetActive(false);
            DeathScreenUI.SetActive(true);
            Debug.Log("your dead");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
