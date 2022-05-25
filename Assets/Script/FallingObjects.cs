using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public bool isFalling = false;

    Vector2 originalPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = originalPos;
    }

    private void Update()
    {
        
    }
    public void Fall() 
    {
        rb.gravityScale = 5;
        isFalling = true;
        trapObject.SetActive(true);
        StartCoroutine(Reset(1));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            revisi.getHit();
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
            //disini bisa dikasih delay biar dia ilang gitu
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            revisi.getHit();
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        trapObject.SetActive(false);
        Debug.Log("reset");
    }
}
