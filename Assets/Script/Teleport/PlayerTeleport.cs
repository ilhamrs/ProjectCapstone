using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public UnityEvent TriggerEvent;

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentTeleporter != null)
            {
                //transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                TriggerEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
