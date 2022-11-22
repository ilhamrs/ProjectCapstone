using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStay : MonoBehaviour
{
    [Header("Main Settings")]
    public string TagObject;
    public UnityEvent TriggerEvent;
    public bool DestroyTrigger;

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            Debug.Log("Berhasil Trigger");
            TriggerEvent.Invoke();
            if (DestroyTrigger)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
