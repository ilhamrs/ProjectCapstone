using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantScriptTrigger : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMove>().Die();
        }
    }
}

