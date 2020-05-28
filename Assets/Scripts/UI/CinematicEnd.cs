using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematicEnd : MonoBehaviour
{
    public GameObject BG;
    public GameObject Illu1;
    public GameObject Illu2;

    private bool delay = false;
    private bool delay1 = false;
    private bool delay2 = false;

    private bool illu5played = false;
    private bool illu6played = false;



    void Update()
    {
        StartCoroutine(Wait(2));
        if (delay == true)
        {
            if (illu5played == false)
            {
                FindObjectOfType<AudioManager>().Play("Illustration5");
                illu5played = true;
            }
            StartCoroutine(FadeToBG(BG, 0f, 1f));
        }
        if (delay1 == true)
        {
            if (illu6played == false)
            {
                FindObjectOfType<AudioManager>().Play("Illustration6");
                illu6played = true;
            }
            StartCoroutine(FadeToIllu1(Illu1, 0f, 1f));
        }
        if (delay2 == true)
        {
            SceneManager.LoadScene("Menu");
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
}
