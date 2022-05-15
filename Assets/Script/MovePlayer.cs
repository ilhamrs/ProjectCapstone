using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D body;
    private bool grounded;
    [SerializeField] private float speed;
    private Animator anim;
    public float JumpForce;
    public AudioSource sfxJump;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horiz * speed, body.velocity.y);

        if (horiz > 0.0f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (horiz < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if(Input.GetKey(KeyCode.Space) && grounded )
        {
            Jump();
        }
        // anim.SetBool("goWalk", horiz != 0);
        // anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        body.velocity = Vector2.up * JumpForce;
        grounded = false;
        sfxJump.Play();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
