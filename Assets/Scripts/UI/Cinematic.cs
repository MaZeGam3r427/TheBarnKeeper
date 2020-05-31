using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    public GameObject BG;
    public GameObject Illu1;
    public GameObject Illu2;
    public GameObject Illu3;
    public GameObject Illu4;

    private bool delay = false;
    private bool delay1 = false;
    private bool delay2 = false;
    private bool delay3 = false;
    private bool delay4 = false;

    private bool illu1played = false;
    private bool illu2played = false;
    private bool illu3played = false;

    void Update()
    {
        StartCoroutine(Wait(2));
        if (delay == true)
        {
            if (illu1played == false)
            {
                FindObjectOfType<AudioManager>().Play("Illustration1");
                illu1played = true;
            }
            
            StartCoroutine(FadeToBG(BG, 0f, 1f));
        }
        if (delay1 == true)
        {
            if (illu2played == false)
            {
                FindObjectOfType<AudioManager>().Play("Illustration2");
                illu2played = true;
            }
            StartCoroutine(FadeToIllu1(Illu1, 0f, 1f));
        }
        if (delay2 == true)
        {
            if (illu3played == false)
            {
                FindObjectOfType<AudioManager>().Play("Illustration3");
                illu3played = true;
            }
            StartCoroutine(FadeToIllu2(Illu2, 0f, 1f));
        }
        if (delay3 == true)
        {
            StartCoroutine(FadeToIllu3(Illu3, 0f, 1f));
        }
        if (delay4 == true)
        {
            SceneManager.LoadScene("Game");
        }

    }

    IEnumerator Wait(float aTime)
    {
        yield return new WaitForSecondsRealtime(aTime);
        delay = true;
    }

    IEnumerator FadeToBG(GameObject Illustration, float aValue, float aTime)
    {
        float alpha = Illustration.GetComponent<Image>().color.a;
        
        for (float i = 0f; i < 7f; i += Time.deltaTime / aTime)
        {
            Color newcolor = new Color(Illustration.GetComponent<Image>().color.r, Illustration.GetComponent<Image>().color.g, Illustration.GetComponent<Image>().color.b, Mathf.Lerp(alpha, aValue, i));
            Illustration.GetComponent<Image>().color = newcolor;
            yield return null;
        }
        delay1 = true;
    }

    IEnumerator FadeToIllu1(GameObject Illustration, float aValue, float aTime)
    {
        float alpha = Illustration.GetComponent<Image>().color.a;
        for (float i = 0f; i < 7f; i += Time.deltaTime / aTime)
        {
            Color newcolor = new Color(Illustration.GetComponent<Image>().color.r, Illustration.GetComponent<Image>().color.g, Illustration.GetComponent<Image>().color.b, Mathf.Lerp(alpha, aValue, i));
            Illustration.GetComponent<Image>().color = newcolor;
            yield return null;
        }
        delay2 = true;
    }

    IEnumerator FadeToIllu2(GameObject Illustration, float aValue, float aTime)
    {
        float alpha = Illustration.GetComponent<Image>().color.a;
        for (float i = 0f; i < 7f; i += Time.deltaTime / aTime)
        {
            Color newcolor = new Color(Illustration.GetComponent<Image>().color.r, Illustration.GetComponent<Image>().color.g, Illustration.GetComponent<Image>().color.b, Mathf.Lerp(alpha, aValue, i));
            Illustration.GetComponent<Image>().color = newcolor;
            yield return null;
        }
        delay3 = true;
    }

    IEnumerator FadeToIllu3(GameObject Illustration, float aValue, float aTime)
    {
        float alpha = Illustration.GetComponent<Image>().color.a;
        for (float i = 0f; i < 7f; i += Time.deltaTime / aTime)
        {
            Color newcolor = new Color(Illustration.GetComponent<Image>().color.r, Illustration.GetComponent<Image>().color.g, Illustration.GetComponent<Image>().color.b, Mathf.Lerp(alpha, aValue, i));
            Illustration.GetComponent<Image>().color = newcolor;
            yield return null;
        }
        delay4 = true;
    }
}
