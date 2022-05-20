using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	[SerializeField] bool IsGrounded;
	public bool isMoving;

	public Animator anim;
	private Rigidbody2D rb;
	public SpriteRenderer sprite;

	public float moveSpeed = 5f;
	public float JumpForce;

	public AudioSource sfxJump;

    private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

    void Update()
	{
		float horiz = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);

		if (horiz > 0.0f)
		{
			isMoving = true;
			sprite.flipX = true;
			anim.SetBool("IsMove", true);
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (horiz < -0.01f)
		{
			isMoving = true;
			sprite.flipX = false;
			anim.SetBool("IsMove", true);
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (Input.GetKey(KeyCode.Space) && IsGrounded)
		{
			Jump();
		}

		//var move = new Vector3(Input.GetAxis("Horizontal"), 0);
		//transform.position += move * moveSpeed * Time.deltaTime;

		//if (Input.GetKey(KeyCode.D))
		//{
		//	isMoving = true;
		//	sprite.flipX = false;
		//	anim.SetBool("IsMove", true);
		//}
		//else if (Input.GetKey(KeyCode.A))
		//{
		//	isMoving = true;
		//	sprite.flipX = true;
		//	anim.SetBool("IsMove", true);
		//}
		//if (!Input.anyKey)
		//{
		//	isMoving = false;
		//	anim.SetBool("IsMove", false);
		//}

	}

	private void Jump()
	{
		anim.SetTrigger("Jump");
		rb.velocity = Vector2.up * JumpForce;
		IsGrounded = false;
		sfxJump.Play();
	}

	void OnCollisionStay2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Ground")
		{
			IsGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D collisionInfo)
	{
		IsGrounded = false;
	}

	private void Deactivate()
	{
		gameObject.SetActive(false);
	}
}