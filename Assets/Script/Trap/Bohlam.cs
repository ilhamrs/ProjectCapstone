using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bohlam : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    public BoxCollider2D boxCollider2D;
    public bool isRising = false;
    public float speed = 5;

    Vector2 originalPos;

    //[Header("Reset Settings")]
    //public UnityEvent TriggerEvent;

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
    public void Rise()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        isRising = true;
        //nyalain object matiin trigger
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            revisi.getHit();
            StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
        if (collision.tag == "Lamp")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }

    //mekanisme reset trap
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
}
