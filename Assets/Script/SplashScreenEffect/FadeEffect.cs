using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void delayFade() 
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
