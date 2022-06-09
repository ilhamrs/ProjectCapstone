using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEffect : MonoBehaviour
{
    public GameObject trapObject;
    public GameObject triggerTrap;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public bool isFalling = false;
    public float fallspeed = 5;

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
        boxCollider2D.enabled = true;
        rb.gravityScale = fallspeed;
        isFalling = true;
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        Debug.Log("reset");
    }
    public void restart()
    {
        StartCoroutine(Reset(1));
    }
}
