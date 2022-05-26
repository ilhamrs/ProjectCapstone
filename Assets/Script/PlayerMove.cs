using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[Header("Components")]
	public Animator anim;
	private Rigidbody2D rb;
	public SpriteRenderer sprite;
	private Collider2D col;

	[Header("Physics")]
	public float moveSpeed = 5f;
	public float JumpForce = 15;
	public Vector2 Checkpoint;
	public bool active = true;
	[SerializeField] bool IsGrounded;
	//public bool isMoving;

	[Header("SFX")]
	[SerializeField] private AudioClip deathSound;
	[SerializeField] private AudioClip hurtSound;
	public AudioSource sfxJump;

	[Header("Objects")]
	[SerializeField] GameObject player;


    private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		//Checkpoint = rb.position;
		SetRespawnPoint(transform.position);
		anim = GetComponent<Animator>();
		col = GetComponent<Collider2D>();
	}

    void Update()
	{
		if (!active) 
		{
			return;
		}
		float horiz = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);

		if (horiz > 0.0f)
		{
			//isMoving = true;
			//sprite.flipX = false;
			//anim.SetBool("goWalk", true);
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (horiz < -0.01f)
		{
			//isMoving = true;
			//sprite.flipX = true;
			//anim.SetBool("goWalk", true);
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			//fungsi jump ada di animasi
			//Jump();
			anim.SetTrigger("goJump");
		}
		anim.SetBool("goWalk", horiz != 0);

		//if (Input.GetKey(KeyCode.D))
		//{
		//	isMoving = true;
		//	sprite.flipX = false;
		//}
		//if (Input.GetKey(KeyCode.A))
		//{
		//	isMoving = true;
		//	sprite.flipX = true;
		//}
	}

	private void Jump()
	{
		//anim.SetTrigger("Jump");
		rb.velocity = Vector2.up * JumpForce;
		IsGrounded = false;
		sfxJump.Play();
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Ground")
		{
			IsGrounded = true;
		}
		else 
		{
			IsGrounded = false;
		}
	}

	public void Respawn()
	{
		//ini dah bener, 0.1f biar jeda spawn karakternya ga keliatan
		Destroy(gameObject, 0.1f);
		//play animasi
		Instantiate(player, Checkpoint, Quaternion.identity);
	}
	private IEnumerator Respawns() 
	{
		yield return new WaitForSeconds(1f);
		transform.position = Checkpoint;
		active = true;
		col.enabled = true;
		MiniJump();
	}

	private void Deactivate()
	{
		gameObject.SetActive(false);
	}

	public void Die() 
	{
		active = false;
		anim.SetTrigger("goDie");
		//ini bisa di false buat efek fall gitu
		//collider.enabled = false;
		MiniJump();
		StartCoroutine(Respawns());
	}
	public void SetRespawnPoint(Vector2 position) 
	{
		Checkpoint = position;
	}

    private void MiniJump()
    {
		rb.velocity = Vector2.up * JumpForce/3;
	}
}