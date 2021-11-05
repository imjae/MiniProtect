using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffolding : MonoBehaviour
{
    bool isStepped = true;

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Scaffolding"))
        {
            isStepped = false;
            GameManager.Instance.ScaffoingNextStep();
            StartCoroutine(BrokeScaffold(3f));
        }
        else if(gameObject.CompareTag("NotScaffolding"))
        {
            StartCoroutine(BrokeScaffold(.5f));
        }
    }

    IEnumerator BrokeScaffold(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
