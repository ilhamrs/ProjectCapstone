using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;
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
        if(distance < Range)
        {
            FollowPlayer();
        }
        // else 
        // {
        //     triggerTulang();
        // }
    }

    private void FollowPlayer()
    {
        if(transform.position.x < player.position.x)
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

    private void triggerTulang()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Tulang")
        {
            triggerTulang();
        }
    }
}
