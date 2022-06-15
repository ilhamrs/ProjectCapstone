using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public bool isFalling = false;
    public float fallspeed = 5;

    Vector2 originalPos;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;

    //[Header("Reset Settings")]
    //public UnityEvent TriggerEvent;

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
        rb.gravityScale = fallspeed;
        isFalling = true;
        //nyalain object matiin trigger
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
    }

    //ini ga terlalu kepake
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            revisi.getHit();
            StartCoroutine(Reset(1));
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            revisi.getHit();
            boxCollider2D.enabled = false;
            StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
        if (collision.tag == "Ground") 
        {
            trapObject.SetActive(false);
        }
    }

    //mekanisme reset trap
   IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        //nyalain trigger matiin object
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        boxCollider2D.enabled = true;
        Debug.Log("reset");
    }

    //ini buat restart yang ditaro di checkpoint
    public void restart() 
    {
        StartCoroutine(Reset(1));
    }
    //public void InvokeTrigger()
    //{
    //    TriggerEvent.Invoke();
    //}
}
