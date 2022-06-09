using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursi : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rb;
    public bool isMove = false;
    public float speed = 5f;

    private Animator anim;

    Vector2 originalPos;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //ini buat bug yang awalnya animasi tidak jalan
        //anim.SetTrigger("isMove");
    }

    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = originalPos;
    }
    public void Bergerak()
    {
        rb.gravityScale = speed;
        isMove = true;
        boxCollider2D.enabled = true;
        //nyalain object matiin trigger
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
        //StartCoroutine(KursiGerak());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            revisi.getHit();
            StartCoroutine(Reset(1));
        }
        if (collision.gameObject.tag == "Ground")
        {
            rb.gravityScale = 0;
            StartCoroutine(KursiGerak());
        }
    }
    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        //nyalain trigger matiin object
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        Debug.Log("reset");
    }

    //ini buat restart yang ditaro di checkpoint
    public void restart()
    {
        StartCoroutine(Reset(1));
    }

    IEnumerator KursiGerak()
    {
        //anim.SetTrigger("isMove");
        yield return new WaitForSeconds(0.3f);
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(3f);
        trapObject.SetActive(false);
    }
}
