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
	public bool IsGrounded;
	public bool isMoving;

	[Header("SFX")]
	[SerializeField] private AudioSource deathSound;
	[SerializeField] private AudioClip hurtSound;
	public AudioSource sfxJump;

	[Header("Objects")]
	[SerializeField] GameObject player;
	[SerializeField] RevisiPanel revisiPanel;

	[Header("Trigger Reset")]
	[SerializeField] Transform reset;

	private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		//Checkpoint = rb.position;
		SetRespawnPoint(transform.position);
		anim = GetComponent<Animator>();
		col = GetComponent<Collider2D>();
	}

    public void Update()
	{
		if (!active) 
		{
			return;
		}
		float horiz = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);

		if (horiz > 0.0f)
		{
			isMoving = true;
			//sprite.flipX = false;
			//anim.SetBool("goWalk", true);
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (horiz < -0.01f)
		{
			isMoving = true;
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
		if (!Input.anyKey)
		{
			isMoving = false;
		}
		anim.SetBool("goWalk", horiz != 0);

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
		if (collisionInfo.gameObject.tag == "Ground" || collisionInfo.gameObject.tag == "Skeleton")
		{
			IsGrounded = true;
		}
		else 
		{
			IsGrounded = false;
		}
	}
	public IEnumerator Respawns() 
	{
		yield return new WaitForSeconds(1f);
		rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
		transform.position = Checkpoint;
		active = true;
		col.enabled = true;
		rb.gravityScale = 6;
		yield return new WaitForSeconds(1f);
		reset.GetComponent<Reset>().ActivateRoom(false);
	}

	private void Deactivate()
	{
		gameObject.SetActive(false);
	}

	public void Die() 
	{
		active = false;
		anim.SetTrigger("goDie");
		col.enabled = false;
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		deathSound.Play();
		StartCoroutine(revisiPanel.showPanel());
		StartCoroutine(Respawns());
	}
	public void SetRespawnPoint(Vector2 position) 
	{
		Checkpoint = position;
	}

}