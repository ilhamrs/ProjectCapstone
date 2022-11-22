using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstantDeathSpoon : MonoBehaviour
{
    [SerializeField] Revisi revision;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.Die();
            revision.getHit();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.GetComponent<PlayerMove>().Die();
            revision.getHit();
        }
    }
}
