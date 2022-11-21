using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySkipCutscene : MonoBehaviour
{
    [Header("Main Settings")]
    public float Delay;
    public GameObject skipCutscene;

    public void active() 
    {
        skipCutscene.SetActive(true);
    }

    void Start()
    {
        Invoke("active", Delay);
    }

}
