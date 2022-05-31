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
    [SerializeField] Revisi revisi;

    public AudioSource sfxDog;
    public Animator anim;

    [SerializeField]
    float Range;
    [SerializeField]
    float speed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        float distance1 = Vector2.Distance(transform.position, Skeleton.position);

        if(distance < Range)
        {
            anim.SetTrigger("Run");
            FollowPlayer();
        }
        else if (distance1 < Range) 
        {
            FollowTulang();
            anim.SetTrigger("Take");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            revisi.getHit();
            StartCoroutine(Reset(1));
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        ResetObject reset = gameObject.GetComponent<ResetObject>();
        //reset.nonactive();
        Debug.Log("reset");
    }
}
