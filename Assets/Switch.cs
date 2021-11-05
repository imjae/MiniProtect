using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool isPush = false;

    public Renderer doorRenderer;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isPush)
        {
            isPush = true;
            // GetComponent<Animator>().SetTrigger("PushTrigger");
            StartCoroutine(FadeOut());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && isPush)
        {   
            isPush = false;
            // GetComponent<Animator>().SetTrigger("PullTrigger");
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        int i = 100;
        while (i > 0)
        {
            i -= 1;
            float f = i / 100f;
            Color c = doorRenderer.material.color;
            c.a = f;
            doorRenderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeIn()    
    {
        int i = 0;
        while (i < 100)
        {
            i += 1;
            float f = i / 100f;
            Color c = doorRenderer.material.color;
            c.a = f;
            doorRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
