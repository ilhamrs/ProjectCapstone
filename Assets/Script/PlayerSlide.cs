using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;

    public PlayerMove playerMove;

    public Rigidbody2D rb;

    public Animator anim;
    public AudioSource sfxSlide;

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;

    public float slideSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerMove.isMoving == true && playerMove.IsGrounded == true && isSliding == false) 
        {
            perfomSlide();
        }
        //DoDelayAction();
    }

    private void perfomSlide() 
    {
        isSliding = true;

        anim.SetBool("goSlide", true);
        sfxSlide.Play();

        regularColl.enabled = false;
        slideColl.enabled = true;

        if (!playerMove.sprite.flipX)
        {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        else
        {
            rb.AddForce(Vector2.left * slideSpeed);
        }

        StartCoroutine("stopslide");

    }

    IEnumerator stopslide() 
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("goSlide", false);
        regularColl.enabled = true;
        slideColl.enabled = false;
        isSliding = false;
    }
    void DoDelayAction()
    {
        StartCoroutine(DelayAction());
    }

    IEnumerator DelayAction()
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(3);

    }
}
