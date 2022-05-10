using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinConditions : MonoBehaviour
{
    public UnityEvent triggerEvent;

    public void InvokeTrigger()
    {
        triggerEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEvent.Invoke();
        }
    }
}
