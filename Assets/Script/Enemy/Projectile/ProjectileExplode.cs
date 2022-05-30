using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplode : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            anim.SetTrigger("isTouching");
            StartCoroutine(DelayTai());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetTrigger("isTouching");
            StartCoroutine(DelayTai());
        }
    }
    private IEnumerator DelayTai() 
    {
        yield return new WaitForSeconds(0.5f);
        //sprite.enabled = false;
    }
}
