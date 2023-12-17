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
	[SerializeField] private AudioSource jatohSound;
	public AudioSource sfxJump;

	[Header("Objects")]
	[SerializeField] GameObject player;
	[SerializeField] RevisiPanel revisiPanel;
	[SerializeField] RevisiPanel revisiPanelRight;
	[SerializeField] RevisiPanel revisiPanelLeft;

	[Header("Trigger Reset")]
	[SerializeField] Transform reset;

	float horiz;
	float horizTouch;

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
		
		horiz = horizTouch;

		if (Input.GetAxis("Horizontal") != 0)
        {
			horiz = Input.GetAxis("Horizontal");
		}

		//horiz = Input.GetAxis("Horizontal");

		//rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);

		if (horiz > 0.0f)
		{
			isMoving = true;
			//sprite.flipX = false;
			//anim.SetBool("goWalk", true);
			transform.localScale = new Vector3(1, 1, 1);
			rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);
		}
		else if (horiz < -0.01f)
		{
			isMoving = true;
			//sprite.flipX = true;
			//anim.SetBool("goWalk", true);
			transform.localScale = new Vector3(-1, 1, 1);
			rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);
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
		anim.SetBool("goWalk", horiz != 0 || horizTouch != 0);

	}

	public void Jump()
	{
        if (IsGrounded)
        {
			anim.SetTrigger("goJump");
			rb.velocity = Vector2.up * JumpForce;
			sfxJump.Play();
			IsGrounded = false;
			//anim.ResetTrigger("goJump");
		}
		
	}
	public void MoveHorizontal(int i)
    {
		horizTouch = i;
		rb.velocity = new Vector2(horizTouch * moveSpeed, rb.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Ground" || collisionInfo.gameObject.tag == "Skeleton" || collisionInfo.gameObject.tag == "EnemyDog")
		{
			//IsGrounded = true;
		}
		else 
		{
			//IsGrounded = false;
		}
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Skeleton") || collision.gameObject.CompareTag("EnemyDog"))
		{
			IsGrounded = true;
			anim.ResetTrigger("goJump");
		}
		else
		{
			IsGrounded = false;
		}
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Ground"))
        {
			IsGrounded = false;
		}

	}
    public IEnumerator Respawns() 
	{
		yield return new WaitForSeconds(1f);
		IsGrounded = true;
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
		jatohSound.Play();
		StartCoroutine(revisiPanel.showPanel());
		//StartCoroutine(revisiPanelRight.showPanel());
		//StartCoroutine(revisiPanelLeft.showPanel());
		StartCoroutine(Respawns());
	}
	public void SetRespawnPoint(Vector2 position) 
	{
		Checkpoint = position;
	}

}