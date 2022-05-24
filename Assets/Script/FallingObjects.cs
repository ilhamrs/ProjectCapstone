using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }
    public void Fall() 
    {
        rb.gravityScale = 5;
        isFalling = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
            //disini bisa dikasih delay biar dia ilang gitu
        }
    }
}
