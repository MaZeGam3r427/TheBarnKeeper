using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    float timer = 0f;
    bool isPlaying = true;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(isPlaying)
        {
            FindObjectOfType<AudioManager>().Play("Main Theme");
            isPlaying = false;
        }

        if(timer >=  31f)
        {
            SceneManager.LoadScene("Menu");
            timer = 0f;
        }
    }
}
