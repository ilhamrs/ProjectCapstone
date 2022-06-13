using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sendok : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    public BoxCollider2D boxCollider2D;
    public bool isOpen = false;

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
    public void Muncul()
    {
        isOpen = true;
        boxCollider2D.enabled = true;
        //nyalain object matiin trigger
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
        StartCoroutine(Sendokmuncul());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            revisi.getHit();
            StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
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

    IEnumerator Sendokmuncul() 
    {
        yield return new WaitForSeconds(0.5f);
        boxCollider2D.enabled = false;
    }
}
