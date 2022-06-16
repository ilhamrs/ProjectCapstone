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
    public GameObject trapObject;
    public GameObject triggerTrap;
    public BoxCollider2D boxCollider2D;

    public AudioSource sfxDog;
    public Animator anim;

    [SerializeField]
    float Range;
    [SerializeField]
    float speed;

    Vector2 originalPos;

    bool getBone;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        sfxDog.Play();
    }

     private void Awake()
    {
        originalPos = transform.localPosition;
        getBone = false;
    }

    private void OnEnable()
    {
        transform.localPosition = originalPos;
        getBone = false;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        float distance1 = Vector2.Distance(transform.position, Skeleton.position);

        if(distance < Range && !getBone)
        {
            anim.SetTrigger("Run");
            FollowPlayer();
        }
        else if (distance1 < Range) 
        {
            //FollowTulang();
            //distance - 5;
            //anim.SetTrigger("Take");
        }
    }

    public void FollowPlayer()
    {
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
        if (transform.position.x < player.position.x)
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

    public void FollowTulang()
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
            boxCollider2D.enabled = false;
            StartCoroutine(Reset(1));
        }

        if(collision.tag == "Skeleton")
        {
            anim.SetTrigger("Take");
            getBone = true;
            boxCollider2D.enabled = false;
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        boxCollider2D.enabled = true;
        Debug.Log("reset");
    }
}
