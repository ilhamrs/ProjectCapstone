using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bohlam : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public BoxCollider2D boxCollider2D;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        //originalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        //transform.localPosition = originalPos;
    }

    private void Update()
    {

    }
    public void Rise()
    {
        //isRising = true;
        ////nyalain object matiin trigger
        //ResetObject reset = gameObject.GetComponent<ResetObject>();
        //reset.active();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            revisi.getHit();
            boxCollider2D.enabled = false;
            //StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
    }

    //mekanisme reset trap
    //IEnumerator Reset(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    //nyalain trigger matiin object
    //    ResetObject reset = gameObject.GetComponent<ResetObject>();
    //    reset.nonactive();
    //    Debug.Log("reset");
    //}

    //ini buat restart yang ditaro di checkpoint
//    public void restart()
//    {
//        StartCoroutine(Reset(1));
//    }
}
