using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Sampah : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    public BoxCollider2D boxCollider2D;

    public Animation anim;
    public Animator animator;
    public SpriteRenderer sprite;
    Vector2 originalPos;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;

    private void Start()
    {
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
    public void Throw() 
    {
        //nyalain object matiin trigger
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
        animator.SetTrigger("throw");
        StartCoroutine(Aktiftrap());
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
            sprite.enabled = true;
            StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
        else
        {
            boxCollider2D.enabled = false;
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
        sprite.enabled = true;
        animator.SetTrigger("idle");
        Debug.Log("reset");
    }

    //ini buat restart yang ditaro di checkpoint
    public void restart() 
    {
        StartCoroutine(Reset(1));
    }
    IEnumerator Aktiftrap(){
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(0.8f);
        boxCollider2D.enabled = false;
        sprite.enabled = false;
        
    }
}
