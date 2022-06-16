using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    //protected void OnCollisionEnter2D(Collision2D other)
    //{
    //    var player = other.collider.GetComponent<PlayerMove>();
    //    if (player != null) 
    //    {
    //        player.Die();
    //    }
    //}

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.GetComponent<PlayerMove>().Die();
        }
    }
}
