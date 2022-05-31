using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public Transform Skeleton;

    public AudioSource sfxDog;

    [SerializeField]
    float Range;
    [SerializeField]
    float speed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        float distance1 = Vector2.Distance(transform.position, Skeleton.position);

        if(distance < Range)
        {
            FollowPlayer();
        }
        else if (distance1 < Range) 
        {
            FollowTulang();
        }
    }

    private void FollowPlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
            sfxDog.Play();
        }
        else 
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void FollowTulang()
    {
        if(transform.position.x < Skeleton.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);

        }
    }
}
